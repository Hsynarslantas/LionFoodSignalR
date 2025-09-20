using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    [AllowAnonymous]
    public class ProgressBarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
