using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class SocialMediaValidation : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Sosyal Medya Adı Boş Olamaz").Length(5,50);
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Sosyal Medya Adresi Boş Olamaz").Length(2, 300);
            RuleFor(x => x.IconPath).NotNull().NotEmpty().WithMessage("Sosyal Medya Icon Resmi Boş Olamaz");
        }
    }
}
