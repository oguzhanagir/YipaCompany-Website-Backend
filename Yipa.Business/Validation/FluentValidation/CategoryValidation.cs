using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Kategori Adı Boş Olamaz").Length(3, 100);
        }
    }
}
