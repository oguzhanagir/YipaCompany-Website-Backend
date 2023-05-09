using FluentValidation;
using FluentValidation.Results;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class AboutManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<About> _validator;

        public AboutManager(IUnitOfWork unitOfWork, IValidator<About> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<About> GetAll()
        {
            var aboutList = _unitOfWork.Abouts.GetAll();
            return aboutList;
        }

        public ValidationResult AddAbout(About about)
        {
            var validation = _validator.Validate(about);

            if (validation.IsValid)
            {
                _unitOfWork.Abouts.Add(about);
                _unitOfWork.Save();
            }
            return validation;
        }

        public void UpdateAbout(About p)
        {
            var about = _unitOfWork.Abouts.Find(x => x.Id == p.Id);
            if (about != null)
            {
                about.Title = p.Title;
                about.Content = p.Content;
                about.ImagePath = p.ImagePath;
                about.Id = p.Id;
                _unitOfWork.Abouts.Update(about);
                _unitOfWork.Save();
            }
        }

        public void DeleteAbout(int id)
        {
            var about = _unitOfWork.Abouts.Find(x => x.Id == id);

            if (about != null)
            {
                _unitOfWork.Abouts.Remove(about);
                _unitOfWork.Save();
            }
        }

        public About GetAboutById(int id)
        {
            var about = _unitOfWork.Abouts.Find(x => x.Id == id);
            return about!;
        }


    }
}
