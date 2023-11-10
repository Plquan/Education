using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Education.WebApp.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly EducationDbContext _context; 
        public ContentController(IContentRepository contentRepository, EducationDbContext context)
        {
            _contentRepository = contentRepository;
            _context = context;
        }

  
        public async Task<IActionResult> Index(int ContentId,string UserId)
        {
           ContentVM ContentDetail = await _contentRepository.GetById(ContentId, UserId);
            return View(ContentDetail);
        }
        [HttpPost]
        public bool AddLike(string CurUserId, int ContentId)      
        {

            try
            {
                Like likes = new Like();
                likes.UserId = CurUserId;
                likes.ContentId = ContentId;
                _context.AddAsync(likes);
                _context.SaveChangesAsync();
                return true;


            }
            catch
            {
                return false;
            }

        }
     

    }
}
