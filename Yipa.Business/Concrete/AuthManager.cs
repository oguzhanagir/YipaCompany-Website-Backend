using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class AuthManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserByEmailAndPasswordAsync(string email)
        {
            var user = _unitOfWork.Users.Find(x => x.Mail == email);

            if (user != null)
            {
                return user;
            }

            return null!;
        }
    }
}
