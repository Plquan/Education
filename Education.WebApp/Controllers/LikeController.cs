using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeRepository _likeRepository;
        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
            
        public async Task<IActionResult> Index(string UserId)
        {
            List<LikeVM> vm = await _likeRepository.GetbyId(UserId);
            return View(vm);
        }
        public async Task<IActionResult> Remove(int ContentId,string UserId)
        {
            var likes = new Like() { 
              ContentId = ContentId,
              UserId = UserId           
            };
            _likeRepository.Delete(likes);
            return View(likes);
        }

    }
}
