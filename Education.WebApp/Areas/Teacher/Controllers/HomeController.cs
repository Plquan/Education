using Education.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        private readonly ITutorRepository _tutorRepository;
        public HomeController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }
        public IActionResult Index()
        {

            return View();
        }

    }
}
