using Microsoft.AspNetCore.Mvc;


namespace Yipa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Header()
        {
            return View();
        }


        public IActionResult Footer()
        {
            return View();
        }



    }
}