using FluentValidation;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Başlık Adı Boş Olamaz").Length(3, 250);
            RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("İçerik Alanı Boş Olamaz").Length(20, 800);
            RuleFor(x => x.ImagePath).NotNull().NotEmpty().WithMessage("Resim Alanı Boş Olamaz");
        }
    }
}
