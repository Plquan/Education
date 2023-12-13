using Education.Application.Interfaces;
using Education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Controllers
{
    
    public class TutorController : Controller
    {
        private readonly ITutorRepository _repository;
        public TutorController(ITutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            List<TutorVM> getall = await _repository.GetAll();
            return View(getall);
        }

    
        public async Task<IActionResult> Detail(string Id)
        {
            TutorDetailVM getdetail = await _repository.GetById(Id);
            return View(getdetail);
        }
    }
}
