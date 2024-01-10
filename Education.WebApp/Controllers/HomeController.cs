using Education.Application;
using Education.Data.EF;
using Education.Data.Entities;
using Education.Data.Enum;
using Education.ViewModel;
using Education.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EducationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

    
        public HomeController(ILogger<HomeController> logger,EducationDbContext educationDbContext, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = educationDbContext;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task <IActionResult> Index()
        {        

            if (_signInManager.IsSignedIn(User))
            {   //session
                //var Id = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
                //cookie
               var Id = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                
                var likes = await _context.Likes.Where( i=> i.UserId == Id).CountAsync();
                var Comments = await _context.Comments.Where(i => i.UserId == Id).CountAsync();
                var BookMarks = await _context.Bookmarks.Where(i => i.UserId == Id).CountAsync();
                var totalcomment = await (from cm in _context.Comments
                                          join c in _context.Contents on cm.ContentId equals c.Id
                                          join p in _context.Playlists on c.PlaylistId equals p.Id
                                          where p.UserId == Id
                                          select cm
                                     ).CountAsync();

                var totalplaylist = await _context.Playlists.CountAsync(x => x.UserId == Id);

                var UserDetail = new UserVM() { 
                CommentCounts = Comments,
                LikeCounts = likes,
                Bookmarks = BookMarks,
                TotalComment = totalcomment,
                TotalPlaylist = totalplaylist
                };
                return View(UserDetail);
            }

            return View();                             
        }

        public async Task<IActionResult> Search(string keyword)
        {       
            if (keyword != null)
            {
                var query = await (from p in _context.Playlists.Include(x => x.AppUser)
                                   where p.Title.Contains(keyword)
                                   select new PlaylistVM()
                                   {
                                       Id = p.Id,
                                       Title = p.Title,
                                       Thumb = p.Thumb,
                                       DateCreated = p.DateCreated,
                                       AppUser = p.AppUser,
                                   }).ToListAsync();
                return View(query);
            }
         return RedirectToAction("Index");
        }

       
            public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}