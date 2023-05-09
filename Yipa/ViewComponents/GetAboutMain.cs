using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;

namespace Yipa.UI.ViewComponents
{
    public class GetAboutMain : ViewComponent
    {
        private readonly AboutManager _aboutManager;

        public GetAboutMain(AboutManager aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IViewComponentResult Invoke()
        {
            var aboutMain = _aboutManager.GetAboutById(2);

            return View(aboutMain);
        }

    }
}
