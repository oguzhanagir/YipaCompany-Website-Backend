using Microsoft.AspNetCore.Mvc;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {

            return RedirectToAction("Index");   
        }
    }
}
