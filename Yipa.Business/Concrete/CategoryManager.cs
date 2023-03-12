using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class CategoryManager
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Category> _validator;

        public CategoryManager(IUnitOfWork unitOfWork, IValidator<Category> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<Category> GetAll()
        {
            var categoryList = _unitOfWork.Categories.GetAll();
            return categoryList;
        }

        public ValidationResult AddCategory(Category category)
        {
            var validation = _validator.Validate(category);

            if (validation.IsValid)
            {
                _unitOfWork.Categories.Add(category);
                _unitOfWork.Save();
            }
            return validation;
        }

        public void UpdateCategory(Category p)
        {
            var category = _unitOfWork.Categories.Find(x => x.Id == p.Id);
            if (category != null)
            {
                category!.Name = p.Name;
                category.Id = p.Id;

                _unitOfWork.Categories.Update(category);
                _unitOfWork.Save();
            }
        }

        public void DeleteCategory(int id)
        {
            var category = _unitOfWork.Categories.Find(x => x.Id == id);

            if (category != null)
            {
                _unitOfWork.Categories.Remove(category);
                _unitOfWork.Save();
            }
        }

        public Category GetCategoryId(int id)
        {
            var category = _unitOfWork.Categories.Find(x => x.Id == id);
            return category!;
        }
    }
}
