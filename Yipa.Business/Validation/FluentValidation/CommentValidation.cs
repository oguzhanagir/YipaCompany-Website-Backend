using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Yorum Başlığı Boş Olamaz").Length(5,200);
            RuleFor(x => x.Mail).NotNull().NotEmpty().WithMessage("Yorum Mail Alanı Boş Olamaz").Length(10,100);
            RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("Yorum İçeriği Boş Olamaz").Length(25,300);
            RuleFor(x => x.PublishDate).NotNull().NotEmpty().WithMessage("Yorum Tarih Alanı Boş Olamaz");
        }
    }
}
