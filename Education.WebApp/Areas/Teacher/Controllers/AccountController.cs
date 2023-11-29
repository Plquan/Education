using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Education.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class AccountController : Controller
    {
       
        public readonly EducationDbContext _Context;
        public readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(EducationDbContext Context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _Context = Context;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
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
                        if (await _userManager.IsInRoleAsync(User, "Tutor"))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["Error"] = "Tài khoản không tồn tại";
                            return View();
                        }

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
            return RedirectToAction("Register", "Account");
        }
    }
}
