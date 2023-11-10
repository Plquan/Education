using Education.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}




























