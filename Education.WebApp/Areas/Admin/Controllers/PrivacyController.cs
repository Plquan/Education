using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
