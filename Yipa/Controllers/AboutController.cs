using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager;

        public AboutController(AboutManager aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminAboutList()
        {
            var blogList = _aboutManager.GetAll();
            return View(blogList);
        }


        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutManager.AddAbout(about);
            return RedirectToAction("AdminAboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var aboutList = _aboutManager.GetAboutById(id);
            return View(aboutList);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _aboutManager.UpdateAbout(about);
            return Redirect("AdminAboutList");
        }

        public IActionResult GetAboutMain()
        {
            return View();
        }

        public IActionResult GetExperienceDetail()
        {
            return View();
        }

        public IActionResult HowWorkDetails()
        {
            return View();
        }


        public IActionResult Features()
        {
            return View();
        }

        public IActionResult AgencyDetails()
        {
            return View();
        }

        public IActionResult GetStarted()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }


    }
}
