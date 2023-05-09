using FluentValidation;
using FluentValidation.Results;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class RoleManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Role> _validator;

        public RoleManager(IUnitOfWork unitOfWork, IValidator<Role> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<Role> GetAll()
        {
            var roleList = _unitOfWork.Roles.GetAll();
            return roleList;
        }

        public ValidationResult AddRole(Role role)
        {
            var validation = _validator.Validate(role);
            if (validation.IsValid)
            {
                _unitOfWork.Roles.Add(role);
                _unitOfWork.Save();
            }
            return validation;
        }

        public void DeleteRole(int id)
        {
            var role = _unitOfWork.Roles.Find(x => x.Id == id);
            if (role != null)
            {
                _unitOfWork.Roles.Remove(role);
                _unitOfWork.Save();
            }
        }

        public void UpdateRole(int id)
        {
            var role = _unitOfWork.Roles.Find(x => x.Id == id);
            if (role != null)
            {
                _unitOfWork.Roles.Update(role);
                _unitOfWork.Save();
            }
        }


    }
}
