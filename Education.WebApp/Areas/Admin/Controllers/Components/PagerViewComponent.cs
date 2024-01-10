using Education.ViewModel.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApp.Areas.Admin.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultbase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
