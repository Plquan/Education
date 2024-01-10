using Education.Data.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly EducationDbContext _context;
        public ContactController(EducationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var getall = await _context.Contacts.ToListAsync();
            return View(getall);
        }
    }
}
