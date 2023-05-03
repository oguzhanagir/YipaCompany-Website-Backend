using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Validation.FluentValidation
{
    public class ServiceValidation : AbstractValidator<Service>
    {
        public ServiceValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Hizmet Başlığı Boş Olamaz").Length(10, 400);
            RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("Hizmet İçeriği Boş Olamaz");

        }
    }
}
