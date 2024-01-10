using Education.Application.Interfaces;
using Education.Application.Repository;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Education.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly EducationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPhotoService _photoService;
        private readonly IUserRepository _userRepository;

        public ProfileController(EducationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager,IPhotoService photoService,IUserRepository userRepository)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
            _userManager = userManager;
            _photoService = photoService;
            _userRepository = userRepository;
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
            if(!ModelState.IsValid)
            {
                ViewBag.message = "name and email can not be null";
                return View(updateProfileVM);
            }
            if (await _userManager.Users.AnyAsync(x => x.Email == updateProfileVM.email && x.Id != updateProfileVM.UserId))
            {
                ViewBag.email = "Email already exists";
                return View("Update", updateProfileVM);
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == updateProfileVM.Name && x.Id != updateProfileVM.UserId))
            {
                ViewBag.name = "Name already exists";
                return View("Update", updateProfileVM);
            }
            var getu = await _userManager.FindByEmailAsync(updateProfileVM.email);
            getu.UserName = updateProfileVM.Name;
                getu.Email = updateProfileVM.email;
            if(updateProfileVM.Image != null)
            {
                var result = await _photoService.AddPhotoAsync(updateProfileVM.Image);
                await _photoService.DeleteAsync(getu.Image);
                getu.Image = result.Url.ToString();
            }
            await _userRepository.Update(getu);
                return Redirect("/Home/Index");            
        }

    }
}
