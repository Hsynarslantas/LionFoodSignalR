using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ClientUserCount()
        {
             return View();
        }
    }
}
