using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class ContentController : Controller
    {
        private readonly IContentRepository _contentRepository;
        public ContentController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int Id)
        {
            PlaylistDetailVM List  = await _contentRepository.GetAllByPlaylist(Id);
            return View(List);
        }

    }
}
