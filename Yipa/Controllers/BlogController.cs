using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager;

        public BlogController(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogHeader()
        {
            return View();
        }
        public IActionResult BlogDetails()
        {
            return View();
        }

        public IActionResult BlogsList()
        {
            return View();
        }

        public IActionResult PopularBlogs()
        {
            return View();
        }

        public IActionResult LatesBlog()
        {
            return View();

        }
        public IActionResult AdminBlogList()
        {
            var blogList = _blogManager.GetAll();
            if (blogList == null)
            {
             // Hata Kontrolü Yapılacak   
            }
            
            return View(blogList);
        }

        public IActionResult MostReadBlogList()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog p)
        {
            _blogManager.AddBlog(p);
            return RedirectToAction("AdminBlogList");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogManager.GetBlogId(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            _blogManager.UpdateBlog(blog);
            return RedirectToAction("AdminBlogList");
        }

        public IActionResult DeleteBlog(int id)
        {
            _blogManager.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
        }


        

    }
}
