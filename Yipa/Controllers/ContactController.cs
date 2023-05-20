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

        


        [HttpGet]
        public IActionResult ContactFormDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactFormDetails(Contact contact)
        {
            try
            {
                await _contactManager.SendEmailAsync(contact);
                TempData["AlertMessage"] = "Başarıyla Gönderildi";
                return RedirectToAction("");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = "E-posta gönderme hatası: " + ex.Message;
                return RedirectToAction("");
            }
           
        }
        public IActionResult ContactFAQ()
        {
            return View();
        }

    }
}
