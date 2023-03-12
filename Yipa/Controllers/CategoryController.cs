using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public CategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AdminCategoryList()
        {
            var categoryList = _categoryManager.GetAll();
            return View(categoryList);
        }
        public IActionResult CategoryList()
        {
            var categoryList = _categoryManager.GetAll();
            return View(categoryList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            _categoryManager.AddCategory(p);
            return RedirectToAction("AdminCategoryList");
        }

        [Authorize]
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryManager.GetCategoryId(id);
            return View(category);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryManager.UpdateCategory(category);
            return RedirectToAction("AdminCategoryList");
        }

        [Authorize]
        public IActionResult DeleteCategory(int id)
        {
            _categoryManager.DeleteCategory(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}
