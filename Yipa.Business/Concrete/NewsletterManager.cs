using FluentValidation;
using FluentValidation.Results;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class NewsletterManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Newsletter> _validator;

        public NewsletterManager(IUnitOfWork unitOfWork, IValidator<Newsletter> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<Newsletter> GetAll()
        {
            var newsletterList = _unitOfWork.Newsletters.GetAll();
            return newsletterList;
        }
        public ValidationResult AddNewsletter(Newsletter newsletter)
        {
            var validation = _validator.Validate(newsletter);

            if (validation.IsValid)
            {
                _unitOfWork.Newsletters.Add(newsletter);
                _unitOfWork.Save();
            }
            return validation;
        }

        public void DeleteNewsletter(int id)
        {
            var newsletter = _unitOfWork.Newsletters.Find(x => x.Id == id);

            if (newsletter != null)
            {
                _unitOfWork.Newsletters.Remove(newsletter);
                _unitOfWork.Save();
            }
        }


        public Newsletter GetNewsletterById(int id)
        {
            var newsletter = _unitOfWork.Newsletters.Find(x => x.Id == id);
            return newsletter!;
        }


    }
}
