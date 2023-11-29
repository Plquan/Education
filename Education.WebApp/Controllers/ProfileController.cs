using Education.Data.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly EducationDbContext _context;
        public ProfileController(EducationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
