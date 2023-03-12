﻿using Microsoft.AspNetCore.Authorization;
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
        public IActionResult AddAbout(About about)
        {
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
