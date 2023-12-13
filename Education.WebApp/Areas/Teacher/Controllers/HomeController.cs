using Education.Application.Interfaces;
using Education.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Tutor")]
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
