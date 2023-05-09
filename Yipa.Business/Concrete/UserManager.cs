using FluentValidation;
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

        public User GetUserById(int id)
        {
            var user = _unitOfWork.Users.Find(x => x.Id == id);
            return user!;
        }

        public void UpdateUser(User p)
        {
            var user = _unitOfWork.Users.Find(x => x.Id == p.Id);
            if (user != null)
            {
                user.FirstName = p.FirstName;
                user.LastName = p.LastName;
                user.Mail = p.Mail;
                user.Password = p.Password;
                user.RoleId = p.RoleId;
                user.Id = p.Id;
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
            }
        }




    }
}
