using FluentValidation;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class NewsletterValidation : AbstractValidator<Newsletter>
    {
        public NewsletterValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Abone Ol Başlık Alanı Boş Olamaz").Length(10, 150);
            RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("Abone Ol İçerik Alanı Boş Olamaz").Length(50, 300);
        }
    }
}
