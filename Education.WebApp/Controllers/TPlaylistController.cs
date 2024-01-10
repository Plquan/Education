using CloudinaryDotNet.Actions;
using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Education.ViewModel.Contents;
using Education.ViewModel.PlaylistViewModel;
using Education.WebApp.Models;
using Education.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{

    [Authorize(Roles = "Tutor")]
    public class TPlaylistController : Controller
    {       
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPhotoService _photoservice;
        private readonly IContentRepository _contentRepository;
        public TPlaylistController(IHttpContextAccessor httpContextAccessor, IPlaylistRepository playlistRepository, IPhotoService photoservice, IContentRepository contentRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _playlistRepository = playlistRepository;
            _photoservice = photoservice;
            _contentRepository = contentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        { 
            var Id = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            List<Playlist> getp = await _playlistRepository.GetbyUserId(Id);

            return View(getp);
        }
        [HttpPost]
        public async Task<int> Remove(int PlaylistId)
        {
            try
            {
                await _playlistRepository.Delete(PlaylistId);
                return 1;
            }
            catch
            {
               return 0;
            }
           
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
                return View(playlistvm);
            }
                   
            var getp = await _playlistRepository.GetbyId(playlistvm.Id);                    
               
                getp.Title = playlistvm.Title;
                getp.Description = playlistvm.Description;
                getp.Status = playlistvm.Status;
            if (playlistvm.Thumb != null)
              {
                  var result = await _photoservice.AddPhotoAsync(playlistvm.Thumb);
                await _photoservice.DeleteAsync(getp.Thumb);
                getp.Thumb = result.Url.ToString();
               }          
            getp.DateCreated = DateTime.UtcNow;
               
            await _playlistRepository.Update(getp);
          
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Detail(int Id)
        {
            PlaylistDetailVM list = await _playlistRepository.getDetail(Id);
            return View(list);
        }
     
        public IActionResult AddContent()
        {          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContent(int Id,CreateContentVM createContentVM)
        {
           
            var result1 = await _photoservice.AddPhotoAsync(createContentVM.Thumb);
            var result2 = await _photoservice.UploadVideoAsync(createContentVM.Video);
            var addnewc = new Content()
            {
                Title = createContentVM.Title,
                PlaylistId = Id,
                Description = createContentVM.Description,
                Status = createContentVM.Status,
                Thumb = result1.Url.ToString(),
                Video = result2.Url.ToString(),
                DateCreated = DateTime.UtcNow
            };
            await _contentRepository.Add(addnewc);
            return Redirect("/TPlaylist/Detail/" + Id + "/");
        }


        public async Task<IActionResult> EditContent(int Id)
        {
            var getc = await _contentRepository.GetById(Id);
            var editcontent = new EditContentVM() { 
              Id = getc.Id,
              Title = getc.Title,
              PlaylistId = getc.PlaylistId,
              Description = getc.Description,
              Status = getc.Status,
              UrlThumb = getc.Thumb,
              UrlVideo = getc.Video,
            };

            return View(editcontent);
        }
        [HttpPost]
        public async Task<IActionResult> EditContent(EditContentVM editContentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(editContentVM);
            }
            var getc = await _contentRepository.GetById(editContentVM.Id);          
            getc.Status = editContentVM.Status;
            getc.Title = editContentVM.Title;
            getc.Description = editContentVM.Description;
            if(editContentVM.Thumb != null) {
               var resulThumb = await _photoservice.AddPhotoAsync(editContentVM.Thumb);
                await _photoservice.DeleteAsync(getc.Thumb);
                getc.Thumb = resulThumb.Url.ToString();
            }
            if (editContentVM.Video != null)
            {
                var resulVideo = await _photoservice.UploadVideoAsync(editContentVM.Video);
                await _photoservice.DeleteAsync(getc.Video);
                getc.Video = resulVideo.Url.ToString();
            }          
            await _contentRepository.Update(getc);
            return Redirect("/TPlaylist/Detail/" + editContentVM.PlaylistId);
        }

        public async Task<IActionResult> ContentDetail(int Id)
        {
            ContentDetail getc = await _contentRepository.ShowContentDetail(Id);
            return View(getc);
        }
    
        
    }
}
