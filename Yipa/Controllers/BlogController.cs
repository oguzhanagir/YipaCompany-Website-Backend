using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlogController(BlogManager blogManager, IHttpContextAccessor httpContextAccessor)
        {
            _blogManager = blogManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult BlogList()
        {
            var blogList = _blogManager.GetAll();
        
            return View(blogList);
        }

        public IActionResult PopularBlogs()
        {
            return View();
        }

        public IActionResult LatesBlog()
        {
            var latesBlogs = _blogManager.LatesBlogList();
            return View(latesBlogs);

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
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBlog(Blog p, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Path.GetFileName(file.FileName);
                string yol = "~/Image/" + dosyaAdi;
                using (var stream = new FileStream(Path.Combine("wwwroot", yol), FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                p.ImagePath = "/Image/" + dosyaAdi;
            }
            _blogManager.AddBlog(p);
            return RedirectToAction("AdminBlogList");
        }

        [Authorize]
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogManager.GetBlogId(id);
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
