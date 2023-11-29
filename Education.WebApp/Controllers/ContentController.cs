using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly EducationDbContext _context; 
        private readonly IHttpContextAccessor _contextAccessor;
        public ContentController(IContentRepository contentRepository, EducationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _contentRepository = contentRepository;
            _context = context;
            _contextAccessor = httpContextAccessor;
        }

  
        public async Task<IActionResult> Index(int ContentId)
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ContentVM ContentDetail = await _contentRepository.GetById(ContentId, Id);
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
                _context.Likes.AddAsync(likes);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public bool RemoveLike(string CurUserId, int ContentId)
        {

            try
            {
                var getlike = _context.Likes.FirstOrDefault(x => x.UserId == CurUserId && x.ContentId == ContentId);
                 _context.Likes.Remove(getlike);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPost]
        public bool AddComment(string message,int ContentId)
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
          
            try
            {
                Comment comment = new Comment()
                {
                    UserId = Id,
                    ContentId = ContentId,
                    Message = message,
                    DateCreated = DateTime.Now,
                };
                _context.AddAsync(comment);
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
