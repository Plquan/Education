using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Education.ViewModel.Users;
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
        public AccountController(EducationDbContext Context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
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
            if (User.Status == Data.Enum.Status.InActive)
            {
                ViewBag.result = "your account was locked";
                return View();
            }
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
                        else
                        {
                            ViewBag.result = "login failed!";
                            return View(loginVM);
                        }
                    }
                    else
                    {
                        ViewBag.password = "Wrong Password!";
                        return View(loginVM);
                    }
             
            }
            ViewBag.account = "Account do not exists";
            return View(loginVM);
        }


            public IActionResult Register()
            {
                return View();
            }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var checkemail = await _userManager.FindByEmailAsync(registerVM.Email);

            if (checkemail != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }
            var result = await _photoservice.AddPhotoAsync(registerVM.Image);
            var User = new AppUser()
            {
                UserName = registerVM.Name,
                Email = registerVM.Email,
                Image = result.Url.ToString(),                        
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

        public  IActionResult ChangePass(string Id)
        {
          
            var getu = new ChangePassVM() { 
             Id = Id,     
            };

            return View(getu);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePass(ChangePassVM changePassVM)
        {
            var user = await _userManager.FindByIdAsync(changePassVM.Id);
                   
                var checkpass = await _userManager.CheckPasswordAsync(user, changePassVM.OldPassword);
                if (checkpass)
                {
                    await _userManager.ChangePasswordAsync(user, changePassVM.OldPassword, changePassVM.NewPassword);
                    await _signInManager.SignOutAsync();
                return RedirectToAction("Login");
                 }
            else
            {
                ViewBag.message = "Wrong Current Password";
                return View();
            }              
        }


        
    }
}
