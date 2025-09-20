using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingalRWebUI.Dtos.ContactDto;
using SingalRWebUI.Dtos.SliderDto;

namespace SingalRWebUI.ViewComponents
{
    public class _LayoutFooterComponentPartial:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
