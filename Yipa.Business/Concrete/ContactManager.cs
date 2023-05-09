using FluentValidation;
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
