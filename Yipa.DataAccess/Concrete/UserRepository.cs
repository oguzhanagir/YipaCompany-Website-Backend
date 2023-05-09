using Microsoft.Extensions.Logging;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(YipaDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {

        }
    }
}
