using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly IWebHostEnvironment _environment;

        public BlogController(BlogManager blogManager, IWebHostEnvironment environment)
        {
            _blogManager = blogManager;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var blogList = _blogManager.GetAll();
            return View(blogList);
        }

        public IActionResult BlogHeader()
        {
            return View();
        }


        public IActionResult BlogDetails(int id)
        {
            var blog = _blogManager.GetBlogId(id);
            return View(blog);
        }


        public IActionResult PopularBlogs()
        {
            var blogList = _blogManager.GetPopularBlogs();
            return View(blogList);
        }

  


        [Authorize]
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

        [Authorize]
        [HttpGet]
        public IActionResult AddBlog()
        {
            ViewBag.Authors = _blogManager.GetUsers();
            ViewBag.Categories = _blogManager.GetCategories();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog p, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath  = "images/" + fileName;

                using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                p.ImagePath = filePath;
            }
            p.Content = Request.Form["Content"];
            _blogManager.AddBlog(p);
            return RedirectToAction("AdminBlogList");
        }

        [Authorize]
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogManager.GetBlogId(id);
            ViewBag.Authors = _blogManager.GetUsers();
            ViewBag.Categories = _blogManager.GetCategories();
            return View(blog);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            _blogManager.UpdateBlog(blog);
            return RedirectToAction("AdminBlogList");
        }

        [Authorize]
        public IActionResult DeleteBlog(int id)
        {
            _blogManager.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
        }




    }
}
