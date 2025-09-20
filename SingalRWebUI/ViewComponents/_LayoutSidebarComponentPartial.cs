using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.ViewComponents
{
    public class _LayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
