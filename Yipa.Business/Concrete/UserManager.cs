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
    public class UserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<User> _validator;

        public UserManager(IUnitOfWork unitOfWork, IValidator<User> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<User> GetAll()
        {
            var userList = _unitOfWork.Users.GetAll();
            return userList;
        }

        public void DeleteUser(int id)
        {
            var user = _unitOfWork.Users.Find(x => x.Id == id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Save();
            }
        }

        


    }
}
