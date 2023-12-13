using Education.Data.EF;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly EducationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public ProfileController(EducationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var getp = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            return View(getp);
        }
        public async Task<IActionResult> Update()
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var getp = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            var user = new UpdateProfileVM() { 
                    Name = getp.UserName,
                    email = getp.Email,                
            };        
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProfileVM updateProfileVM)
        {        
            return View();
        }

    }
}
