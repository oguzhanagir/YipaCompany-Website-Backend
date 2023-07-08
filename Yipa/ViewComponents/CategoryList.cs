using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;

namespace Yipa.UI.ViewComponents
{
    [ViewComponent]
    public class CategoryList : ViewComponent
    {
        private readonly CategoryManager _categoryManager;

        public CategoryList(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogByCategoryList = _categoryManager.GetAll();

            return View(getBlogByCategoryList);
        }
    }
}
