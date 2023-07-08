using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;

namespace Yipa.UI.ViewComponents
{
    [ViewComponent]
    public class LatestBlogs : ViewComponent
    {
        private readonly BlogManager _blogManager;

        public LatestBlogs(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var blogList = _blogManager.GetAll();

            return View(blogList);
        }
    }
}
