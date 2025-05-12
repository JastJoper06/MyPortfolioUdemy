using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioUdemy.ViewComponents.LayoutViewComponent
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
