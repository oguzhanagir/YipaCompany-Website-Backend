using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class SocialMediaManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<SocialMedia> _validator;

        public SocialMediaManager(IUnitOfWork unitOfWork, IValidator<SocialMedia> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<SocialMedia> GetAll() 
        {
            var socialMediaList = _unitOfWork.SocialMedias.GetAll();
            return socialMediaList;
        }

        public ValidationResult AddSocialMedia(SocialMedia socialMedia)
        {
            var validation = _validator.Validate(socialMedia);
            if (validation.IsValid)
            {
                _unitOfWork.SocialMedias.Add(socialMedia);
                _unitOfWork.Save();
            }
            return validation;
        }

        public void DeleteSocialMedia(int id)
        {
            var socialMedia = _unitOfWork.SocialMedias.Find(x=>x.Id == id);
            if (socialMedia != null)
            {
                _unitOfWork.SocialMedias.Remove(socialMedia);
                _unitOfWork.Save();
            }
        }


        public void UpdateSocialMedia(SocialMedia p)
        {
            var socialMedia = _unitOfWork.SocialMedias.Find(x => x.Id == p.Id);
            if (socialMedia != null)
            {
                socialMedia.Id = p.Id;
                socialMedia.Name = p.Name;
                socialMedia.Address = p.Address;
                socialMedia.IconPath = p.IconPath;
                
                _unitOfWork.SocialMedias.Update(socialMedia);
                _unitOfWork.Save();
            }
        }

        public SocialMedia GetSocialMediaById(int id)
        {
            var socialMedia = _unitOfWork.SocialMedias.Find(x => x.Id == id);
            return socialMedia!;
        }
    }
}
