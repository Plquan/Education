using Education.Data.EF;
using Education.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{
  
    public class ContactController : Controller
    {
        private readonly EducationDbContext _context;
        public ContactController(EducationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<int> Create(string name, string phone, string email, string message)
        {            
            try
            {
                Contact contact = new Contact()
                {
                   Name = name,
                   PhoneNumber = phone,
                   Email = email,
                   Message = message,
                   DateCreated = DateTime.UtcNow,
            };
               await _context.Contacts.AddAsync(contact);
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
