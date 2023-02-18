using Microsoft.AspNetCore.Mvc;

namespace Yipa.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
