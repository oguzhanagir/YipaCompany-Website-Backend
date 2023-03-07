using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly SocialMediaManager _socialMediaManager;

        public SocialMediaController(SocialMediaManager socialMediaManager)
        {
            _socialMediaManager = socialMediaManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminSocialMediaList()
        {
            var socialMedia = _socialMediaManager.GetAll();
            return View(socialMedia);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaManager.AddSocialMedia(socialMedia);
            return RedirectToAction("AdminSocialMediaList");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = _socialMediaManager.GetSocialMediaById(id);
            return View();
        }

        [HttpPost]
        public IActionResult UpdateocialMedia(SocialMedia socialMedia)
        {
            _socialMediaManager.UpdateSocialMedia(socialMedia);
            return RedirectToAction("AdminSocialMediaList");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            _socialMediaManager.DeleteSocialMedia(id);
            return RedirectToAction("AdminSocialMediaList");
        }


    }
}
