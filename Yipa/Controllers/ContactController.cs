using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactManager _contactManager;

        public ContactController(ContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HeaderContact()
        {
            return View();
        }

        public IActionResult ContactDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            return View();
        }

        public IActionResult ContactFormDetails()
        {
            return View();
        }
        public IActionResult ContactFAQ()
        {
            return View();
        }

    }
}
