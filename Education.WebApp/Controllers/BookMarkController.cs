using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Education.WebApp.Controllers
{

    public class BookMarkController : Controller
    {
        private readonly IBookMarkRepository _bookMarkRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public BookMarkController(IBookMarkRepository bookMarkRepository, IHttpContextAccessor contextAccessor)
        {
            _bookMarkRepository = bookMarkRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            BookMarkVM getbyId = await _bookMarkRepository.GetbyId(Id);
            return View(getbyId);
        }
     
    }
}
