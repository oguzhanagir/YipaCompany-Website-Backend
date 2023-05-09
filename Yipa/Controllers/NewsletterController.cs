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


        public IActionResult MainNewsletter()
        {
            return View();
        }


    }
}
