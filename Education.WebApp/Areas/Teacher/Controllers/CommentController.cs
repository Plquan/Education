using Education.Application.Interfaces;
using Education.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Windows.Input;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class CommentController : Controller
    {
       private readonly ICommentRepository _commentRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CommentController(ICommentRepository commentRepository, IHttpContextAccessor contextAccessor)
        {
            _commentRepository = commentRepository;
            _contextAccessor = contextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            List<Comment> getall = await _commentRepository.GetAllCommentByTutor(Id);
            return View(getall);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _commentRepository.Delete(Id);
            return View();
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
    }
}
