using Education.Data.EF;
using Education.Data.Entities;

using Education.WebApp.Models;
using Education.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{
 
    public class AccountController : Controller
    {
        public readonly EducationDbContext _Context;
        public readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoservice;
        public AccountController(EducationDbContext Context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IPhotoService photoService )
        { 
            _userManager = userManager;
            _Context = Context;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _photoservice = photoService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var User = await _userManager.FindByEmailAsync(loginVM.Email);
            if (User != null)
            {
                var checkpass = await _userManager.CheckPasswordAsync(User, loginVM.Password);
                if (checkpass)
                {                           
                    
                    var result = await _signInManager.PasswordSignInAsync(User, loginVM.Password, false, false);
                    if (result.Succeeded)
                    { 
                        
                            return RedirectToAction("Index", "Home");                      
                      
                                            
                    }
                    TempData["Error"] = "Wrong credentials. Please try again";
                    return View(loginVM);
                }
            }
            TempData["Error"] = "Wrong Email. Pls Try Again";
            return View(loginVM);
        }


            public IActionResult Register()
            {
                return View();
            }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var checkemail = await _userManager.FindByEmailAsync(registerVM.Email);

            if (checkemail != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }
            var User = new AppUser()
            {
                UserName = registerVM.Name,
                Email = registerVM.Email,
                Image = "/images/" + registerVM.Image,     
            };
              var NewUser = await _userManager.CreateAsync(User,registerVM.Password);
            if (NewUser.Succeeded)
            {
               await _userManager.AddToRoleAsync(User,"Student");
                return RedirectToAction("Index", "Home");
                
            }        
            return View(registerVM);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
