using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    public class ProfileController : Controller
    {
        [Area("Teacher")]
        [Authorize(Roles = "Tutor")]
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
