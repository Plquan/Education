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
        public bool Create(string name, string phone, string email, string message)
        {
            try
            {
                Contact contact = new Contact();
                contact.Name = name;
                contact.PhoneNumber = phone;
                contact.Email = email;
                contact.Message = message;

                _context.AddAsync(contact);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
