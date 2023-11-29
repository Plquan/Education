using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    public class ProfileController : Controller
    {
        [Area("Teacher")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
    }
}
