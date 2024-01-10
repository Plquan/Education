using Education.Application.Interfaces;
using Education.Data.EF;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.WebApp.Controllers
{   
    public class TutorController : Controller
    {
        private readonly ITutorRepository _repository;
        private readonly EducationDbContext _context;
        public TutorController(ITutorRepository repository, EducationDbContext educationDbContext)
        {
            _repository = repository;
            _context = educationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<TutorVM> getall = await _repository.GetAll();
            return View(getall);
        }

    
        public async Task<IActionResult> Detail(string Id)
        {
            TutorDetailVM getdetail = await _repository.GetById(Id);
            return View(getdetail);
        }
        
        public async Task<IActionResult> Search(string keyword)
        {
            if(keyword != null)
            {
                var query = await (from u in _context.Users
                                                   join r in _context.UserRoles on u.Id equals r.UserId
                                                   join ur in _context.Roles on r.RoleId equals ur.Id
                                                   where ur.Name == "Tutor" && u.UserName.Contains(keyword)
                                                   select new TutorVM()
                                                   {
                                                       UserId = u.Id,
                                                       UserName = u.UserName,
                                                       UserImage = u.Image,
                                                       PlaylistCount = u.Playlists.Count,
                                                       LikeCount = u.Playlists.SelectMany(c => c.Contents.SelectMany(x => x.Likes)).Count(),
                                                       VideoCount = u.Playlists.SelectMany(playlist => playlist.Contents).Count()
                                                   }).Distinct().ToListAsync();
                return View(query);
            }
            return View();

        }
    }
}
