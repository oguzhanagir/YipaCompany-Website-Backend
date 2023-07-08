using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult AdminAboutList()
        {
            var aboutList = _aboutManager.GetAll();
            return View(aboutList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAbout(About about, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/services", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                about.ImagePath = filePath;
            }
            _aboutManager.AddAbout(about);
            return RedirectToAction("AdminAboutList");
        }

        [Authorize]
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var aboutList = _aboutManager.GetAboutById(id);
            return View(aboutList);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _aboutManager.UpdateAbout(about);
            return RedirectToAction("AdminAboutList", "About");
        }


        public IActionResult DeleteAbout(int id)
        {
            _aboutManager.DeleteAbout(id);
            return RedirectToAction("AdminAboutList", "About");
        }
        public IActionResult GetAboutMain()
        {
            var aboutMain = _aboutManager.GetAboutById(1);
            return PartialView("GetAboutMain", aboutMain);
        }

       

        public IActionResult OurCompany()
        {
            return View();
        }

        public IActionResult Features()
        {
            return View();
        }

        public IActionResult TeamSection()
        {
            return View();
        }






    }
}
