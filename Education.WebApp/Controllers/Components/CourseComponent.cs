using Education.Data.EF;
using Education.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.WebApp.Controllers.Components
{
    [ViewComponent(Name = "Course")]
    public class CourseComponent : ViewComponent
    {
        private readonly EducationDbContext _context;
        public CourseComponent(EducationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Getplaylist = await (from p in _context.Playlists.Include(x => x.AppUser)
                                     select new PlaylistVM()
                                     {
                                         Id = p.Id,
                                         Title = p.Title,
                                         Thumb = p.Thumb,
                                         DateCreated = p.DateCreated,
                                         AppUser = p.AppUser,
                                     }).ToListAsync();
            return await Task.FromResult((IViewComponentResult)View("Default", Getplaylist));
        }

    }
}
