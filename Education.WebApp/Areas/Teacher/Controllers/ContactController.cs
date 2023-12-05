using Education.Application.Interfaces;
using Education.Data.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class ContactController : Controller
    {
        private readonly EducationDbContext _context;

        public ContactController(EducationDbContext context)
        {
            _context = context;
       
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getall = await _context.Contacts.ToListAsync();        
            return View(getall);
        }

        [HttpPost]
        public async Task<int> DeleteMessage(int ContactId)
        {
            var getc = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == ContactId);
            try
            {     
                _context.Contacts.Remove(getc);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}
