using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{

    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentController(ICommentRepository commentRepository, IHttpContextAccessor contextAccessor)
        {
            _commentRepository = commentRepository;
            _httpContextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var Id = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            List<UserCommentVM> getC = await _commentRepository.GetbyId(Id);
            return View(getC);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var Getc = await _commentRepository.GetCommentbyId(Id);
            if (Getc == null) return View("Error");
            var Comment = new Comment() {
                Id = Getc.Id,
                UserId = Getc.UserId,
                ContentId = Getc.ContentId,
                Message = Getc.Message,
                DateCreated = Getc.DateCreated
                
            };
            return View(Comment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Comment comment)
        {           
            await _commentRepository.Update(comment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
           await _commentRepository.Delete(Id);

            return RedirectToAction("Index");

        }


    }
}




























