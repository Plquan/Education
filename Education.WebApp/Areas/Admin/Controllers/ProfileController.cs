using Education.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Education.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
       private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        public ProfileController(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var getu = await _userRepository.getbyId(Id);
            return View(getu);
        }
    }
}
