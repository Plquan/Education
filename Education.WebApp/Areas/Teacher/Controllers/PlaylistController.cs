using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Education.ViewModel.PlaylistViewModel;
using Education.WebApp.Models;
using Education.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Education.WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class PlaylistController : Controller
    {       
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPhotoService _photoservice;
        public PlaylistController(IHttpContextAccessor httpContextAccessor, IPlaylistRepository playlistRepository, IPhotoService photoservice)
        {
            _httpContextAccessor = httpContextAccessor;
            _playlistRepository = playlistRepository;
            _photoservice = photoservice;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Id = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            List<Playlist> getp = await _playlistRepository.GetbyUserId(Id);

            return View(getp);
        }
        
        public async Task<IActionResult> Remove(int Id)
        {
            await _playlistRepository.Delete(Id);
           
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreatePlaylistVM playlistvm)
        {
            if (!ModelState.IsValid)
            {
                return View(playlistvm);
            }
            var Id = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _photoservice.AddPhotoAsync(playlistvm.Thumb);
            var create = new Playlist()
            {
                UserId = Id,
                Title = playlistvm.Title,
                Description = playlistvm.Description,
                Thumb = result.Url.ToString(),
                DateCreated = DateTime.UtcNow,
                Status = playlistvm.Status,
            };
            _ = await _playlistRepository.Add(create);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var PlaylistDetail = await _playlistRepository.GetbyId(Id);
     
            var getp = new EditPlaylistVM() { 
                UserId = PlaylistDetail.UserId,
                Title = PlaylistDetail.Title,
                Description = PlaylistDetail.Description,
                Status = PlaylistDetail.Status, 
                Url = PlaylistDetail.Thumb
            };


            return View(getp);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditPlaylistVM playlistvm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit playlist");
                return View(playlistvm);
            }
                   
            var getp = await _playlistRepository.GetbyId(playlistvm.Id);
            if (playlistvm.Thumb != null)
            {
                await _photoservice.DeletePhotoAsync(getp.Thumb);
                var result = await _photoservice.AddPhotoAsync(playlistvm.Thumb);
                getp.Title = playlistvm.Title;
                getp.Description = playlistvm.Description;
                getp.Status = playlistvm.Status;
                getp.Thumb = result.Url.ToString();
                getp.DateCreated = DateTime.UtcNow;
            }
            else
            {
                getp.Title = playlistvm.Title;
                getp.Description = playlistvm.Description;
                getp.Status = playlistvm.Status;
                getp.Thumb = getp.Thumb;
                getp.DateCreated = DateTime.UtcNow;
            }         
            await _playlistRepository.Update(getp);
          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            PlaylistDetailVM list = await _playlistRepository.getDetail(Id);
            return View(list);
        }

       
    }
}
