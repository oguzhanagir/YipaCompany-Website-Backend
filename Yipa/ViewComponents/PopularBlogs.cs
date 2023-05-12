using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;

namespace Yipa.UI.ViewComponents
{
    public class PopularBlogs : ViewComponent
    {
        private readonly BlogManager _blogManager;

        public PopularBlogs(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var popularBlogs = _blogManager.GetPopularBlogs();
            return View(popularBlogs);
        }
    }
}
