using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceManager _serviceManager;

        public ServiceController(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminServiceList()
        {
            var serviceList = _serviceManager.GetAll();
            return View(serviceList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddService()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceManager.AddService(service);
            return RedirectToAction("AdminServiceList", "Service");
        }


        [Authorize]
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var service = _serviceManager.GetServiceId(id);
            return View(service);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _serviceManager.UpdateService(service);
            return RedirectToAction("AdminServiceList");
        }

        [Authorize]
        public IActionResult DeleteService(int id)
        {
            _serviceManager.DeleteService(id);
            return RedirectToAction("AdminServiceList");
        }


        public IActionResult ServiceMainDetails()
        {
            return View();
        }

        public IActionResult HeaderService()
        {
            return View();
        }

        public IActionResult ServiceAbout()
        {
            return View();
        }

        public IActionResult ServicesDetails()
        {
            return View();
        }
        public IActionResult ListMainService()
        {
            var serviceList = _serviceManager.GetAll();
            return View(serviceList);
        }
    }
}
