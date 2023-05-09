using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;

namespace Yipa.UI.ViewComponents
{
    public class ListMainService: ViewComponent
    {
        private readonly ServiceManager _serviceManager;

        public ListMainService(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var serviceList = _serviceManager.GetAll();

            return View(serviceList);
        }
    }
}
