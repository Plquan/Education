using Azure.Core;
using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.Data.Enum;
using Education.ViewModel;
using Education.ViewModel.Users;
using Education.WebApp.Models;
using Education.WebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPhotoService _photoService;
     
        public UserController(IUserRepository userRepository, UserManager<AppUser> userManager, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index(int PageIndex = 1, int PageSize = 3)
        {
            
            var getAll = await _userRepository.GetAllUserPaging(PageIndex,PageSize);
            if (TempData["Result"] != null)
            {
                ViewBag.Success = TempData["Result"];
            }
            return View(getAll);
        }



        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserVM createUserVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["Failed"] = "Invalid";
                return View("Create", createUserVM);
            }

            var checkemail = await _userManager.FindByEmailAsync(createUserVM.Email);
            if (checkemail != null)
            {
                ViewBag.email = "Email already exists";
                return View("Create", createUserVM);
            }
            var checkname = await _userManager.FindByNameAsync(createUserVM.Name);
            if(checkname != null)
            {
                ViewBag.name = "Name already exists";
                return View("Create", createUserVM);
            }
            var urlImage = await _photoService.AddPhotoAsync(createUserVM.Image);
            var newuser = new AppUser()
            {
                UserName = createUserVM.Name,
                Email = createUserVM.Email,
                Image = urlImage.Url.ToString(),
            };
            var result = await _userManager.CreateAsync(newuser, createUserVM.ConfirmPassword);
            if (result.Succeeded)
            {
                if(createUserVM.Role == true)
                {
                    await _userManager.AddToRoleAsync(newuser,"Tutor");
                }               
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", createUserVM);
            }

        }

        public async Task<IActionResult> Edit(string Id)
        {
            var getu = await _userRepository.getbyId(Id);
            var edit = new UpdateProfileVM() { 
            UserId = Id,
            Name = getu.Name,
            email = getu.Email,
            };
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProfileVM updateProfileVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "name and email can not be null";
                return View(updateProfileVM);
            }
            if (await _userManager.Users.AnyAsync(x => x.Email == updateProfileVM.email && x.Id != updateProfileVM.UserId))
            {
                ViewBag.email = "Email already exists";
                return View("Edit", updateProfileVM);
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == updateProfileVM.Name && x.Id != updateProfileVM.UserId))
            {
                ViewBag.name = "Name already exists";
                return View("Edit", updateProfileVM);
            }
            var getu = await _userManager.FindByIdAsync(updateProfileVM.UserId);
            getu.UserName = updateProfileVM.Name;
            getu.Email = updateProfileVM.email;
            if (updateProfileVM.Image != null)
            {
                var result = await _photoService.AddPhotoAsync(updateProfileVM.Image);
                await _photoService.DeleteAsync(getu.Image);
                getu.Image = result.Url.ToString();
            }
            await _userRepository.Update(getu);
            TempData["Result"] = "Edit Success";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(string Id)
        {         
             await _userRepository.Delete(Id);
            return RedirectToAction("Index");
           
        }
        [HttpPost]
        public async Task<int> CheckStatus(string Id,int status)
        {
            var getu = await _userManager.FindByIdAsync(Id);
            try
            {        
                getu.Status = status == 1 ? Status.Active : Status.InActive;
               await _userRepository.Update(getu);

                return 1;
            }
            catch {

                return 0;
            }
        }

        public async Task<IActionResult> RoleAssign(string Id)
        {
            var getu = await _userManager.FindByIdAsync(Id);
            var check = await _userManager.IsInRoleAsync(getu, "Admin");
            var role = new RoleAssignRequest() { 
              Id = Id,
              IsAdmin = check           
            };          
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
        {
            var getu = await _userManager.FindByIdAsync(request.Id);
            if(request.IsAdmin)
            {
                if(await _userManager.IsInRoleAsync(getu, "Admin") == false)
                {
                    await _userManager.AddToRoleAsync(getu, "Admin");
                }
            }
            else
            {
                if(await _userManager.IsInRoleAsync(getu,"Admin") == true)
                {
                    await _userManager.RemoveFromRoleAsync(getu, "Admin");
                }
            }
            TempData["Result"] = "Role Assign Success";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Profile(string Id)
        {
            var getu = await _userManager.FindByIdAsync(Id);
           return View(getu);
        }

      }
}
