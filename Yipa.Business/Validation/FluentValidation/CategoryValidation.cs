using FluentValidation;
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
