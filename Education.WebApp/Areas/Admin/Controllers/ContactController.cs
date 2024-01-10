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
            if (TempData["result"] != null)
            {
                ViewBag.message = TempData["result"];
            }
            return View(getall);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            _context.Contacts.Remove(query);
            _context.SaveChanges();
            TempData["result"] = "delete message successful";
            return RedirectToAction("Index");
        }
    }
}
