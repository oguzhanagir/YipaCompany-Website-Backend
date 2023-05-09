using FluentValidation;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class RoleValidation : AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Rol Adı Boş Olamaz").Length(3, 100);
        }
    }
}
