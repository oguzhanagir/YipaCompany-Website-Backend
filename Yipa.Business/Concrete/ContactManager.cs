using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class ContactManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Contact> _validator;

        public ContactManager(IUnitOfWork unitOfWork, IValidator<Contact> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }



    }
}
