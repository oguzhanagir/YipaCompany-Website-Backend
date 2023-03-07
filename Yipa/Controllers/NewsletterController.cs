using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly NewsletterManager _newsletterManager;

        public NewsletterController(NewsletterManager newsletterManager)
        {
            _newsletterManager = newsletterManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminNewsletterList()
        {
            var newsletterList = _newsletterManager.GetAll();
            return View(newsletterList);
        }

        [HttpGet]
        public IActionResult AddNewsletter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewsletter(Newsletter newsletter)
        {
            _newsletterManager.AddNewsletter(newsletter);
            return View();
        }

      
        public IActionResult DeleteNewsletter(int id)
        {
            _newsletterManager.DeleteNewsletter(id);
            return RedirectToAction("AdminNewsletterList");
        }

        [HttpGet]
        public IActionResult UpdateNewsletter(int id)
        {
            var newsletter = _newsletterManager.GetNewsletterById(id);
            return View(newsletter);
        }

        [HttpPost]
        public IActionResult UpdateNewsletter(Newsletter newsletter)
        {
            _newsletterManager.UpdateNewsletter(newsletter);
            return View();
        }

        public IActionResult MainNewsletter()
        {
            return View();
        }


    }
}
