using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.ViewComponents
{
    public class _LayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
