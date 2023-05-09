using FluentValidation;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Blog Başlığı Boş Olamaz").Length(10, 400);
            RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("Blog İçerik Alanı Boş Olamaz");
            RuleFor(x => x.PublicDate).NotNull().NotEmpty().WithMessage("Blog Tarihi Alanı Boş Olamaz");
            RuleFor(x => x.ImagePath).NotNull().NotEmpty().WithMessage("Blog Bannerı Boş Olamaz");
        }
    }
}
