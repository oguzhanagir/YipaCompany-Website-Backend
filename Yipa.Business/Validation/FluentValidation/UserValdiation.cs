using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class UserValdiation : AbstractValidator<User>
    {
        public UserValdiation()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("Kullanıcı İlk Adı Boş Olamaz").Length(2, 100);
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Kullanıcı Soy Adı Boş Olamaz").Length(2, 100);
            RuleFor(x => x.Mail).NotEmpty().NotNull().WithMessage("Kullanıcı Maili Boş Olamaz").Length(2, 100);
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Kullanıcı Şifre Alanı Boş Olamaz");
        }
    }
}
