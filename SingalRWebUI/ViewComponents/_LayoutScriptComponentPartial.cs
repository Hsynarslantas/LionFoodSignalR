using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.ViewComponents
{
    public class _LayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
