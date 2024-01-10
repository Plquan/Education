using Education.Application.Interfaces;
using Education.Application.Repository;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IBookMarkRepository _bookMarkRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PlaylistController(IPlaylistRepository playlistRepository, IHttpContextAccessor httpContextAccessor,IBookMarkRepository bookMarkRepository) 
        {
                _playlistRepository = playlistRepository;
            _httpContextAccessor = httpContextAccessor;
            _bookMarkRepository = bookMarkRepository;
        }
        public async Task <IActionResult> Index()
        {
            List<PlaylistVM> GetAll = await _playlistRepository.GetAll();
            return View(GetAll);
        }

    
        public async Task<IActionResult> Detail(PlaylistDetailVM playlistDetailVM)
        {           
            var detailplaylist = await _playlistRepository.getDetail(playlistDetailVM.Id);

            return View(detailplaylist);
        }
        [HttpPost]
        public async Task<int> AddBookMark(string CurUserId, int PlaylistId)
        {
            var Id = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            try
            {
                BookMark bookmark = new BookMark()
                {
                    UserId = CurUserId,
                    PlaylistId = PlaylistId
                };
                await _bookMarkRepository.Add(bookmark);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        [HttpPost]
        public async Task<int> RemoveBookMark(string CurUserId, int PlaylistId)
        {
            try
            {        
                await _bookMarkRepository.Remove(CurUserId, PlaylistId);
                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}
