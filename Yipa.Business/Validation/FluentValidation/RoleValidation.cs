using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
