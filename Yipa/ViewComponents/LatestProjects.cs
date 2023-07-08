using Microsoft.AspNetCore.Mvc;

namespace Yipa.UI.ViewComponents
{
    public class LatestProjects:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
