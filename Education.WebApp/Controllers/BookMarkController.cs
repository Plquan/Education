using Education.Application.Interfaces;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{
    public class BookMarkController : Controller
    {
        private readonly IBookMarkRepository _bookMarkRepository;
        public BookMarkController(IBookMarkRepository bookMarkRepository)
        {
            _bookMarkRepository = bookMarkRepository;
        }

        public async Task<IActionResult> Index(string UserId)
        {
            BookMarkVM getbyId = await _bookMarkRepository.GetbyId(UserId);
            return View(getbyId);
        }
     
    }
}
