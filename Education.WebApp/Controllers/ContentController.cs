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

    public class ContentController : Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICommentRepository _commentRepository;
        public ContentController(IContentRepository contentRepository,IHttpContextAccessor httpContextAccessor, ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            _contentRepository = contentRepository;
            _contextAccessor = httpContextAccessor;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
        }

  
        public async Task<IActionResult> Index(int ContentId)
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ContentVM ContentDetail = await _contentRepository.getContentDetail(ContentId, Id);
            return View(ContentDetail);
        }


        [HttpPost]
        public async Task<int> AddLike(string CurUserId, int ContentId)      
        {           
            try
            {
                Like likes = new Like();
                likes.UserId = CurUserId;
                likes.ContentId = ContentId;
              await  _likeRepository.Add(likes);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [HttpPost]
        public async Task<int> RemoveLike(string CurUserId, int ContentId)
        {
            try
            {            
              await  _likeRepository.Remove(CurUserId,ContentId);

                return 1;
            }
            catch
            {
                return 0;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(string message,int ContentId)
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;       
                Comment comment = new Comment()
                {
                    UserId = Id,
                    ContentId = ContentId,
                    Message = message,
                    DateCreated = DateTime.UtcNow,
                };               
              await _commentRepository.Add(comment);
                return Json(comment);
            
           
        }

        [HttpPost]
        public async Task<int> DeleteComment(int CommentId)
        {
            try
            {           
                await _commentRepository.Delete(CommentId);
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(int Id,string message)
        {
              var getc = await _commentRepository.GetCommentbyId(Id);
                getc.Message = message;
                getc.DateCreated = DateTime.UtcNow;
                await _commentRepository.Update(getc);
              return Json(getc);
            

        }


    }
}
