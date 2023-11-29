using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{

    public class PlaylistController : Controller
    {
        private readonly IPlaylistRepository _playlistRepository;
        public PlaylistController(IPlaylistRepository playlistRepository) 
        {
                _playlistRepository = playlistRepository;
        }
        public async Task <IActionResult> Index()
        {
            List<PlaylistVM> GetAll = await _playlistRepository.GetAll();
            return View(GetAll);
        }

    
        public async Task<IActionResult> Detail(PlaylistDetailVM playlistDetailVM)
        {           
            var detailplaylist = await _playlistRepository.GetContentById(playlistDetailVM.Id);

            return View(detailplaylist);
        }

    }
}
