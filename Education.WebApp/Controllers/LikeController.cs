using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{
    [Authorize]
    public class LikeController : Controller
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IHttpContextAccessor _httpcontextAccessor;
        public LikeController(ILikeRepository likeRepository, IHttpContextAccessor httpcontextAccessor)
        {
            _likeRepository = likeRepository;
            _httpcontextAccessor = httpcontextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var Id = _httpcontextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            List<LikeVM> vm = await _likeRepository.GetbyId(Id);
            return View(vm);
        }

       
        public async Task<IActionResult> Remove(int ContentId,string UserId)
        {     
          await _likeRepository.Remove(UserId,ContentId);
            return RedirectToAction("Index");
        }

    }
}
