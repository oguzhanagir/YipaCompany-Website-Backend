using Microsoft.Extensions.Logging;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Concrete
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(YipaDbContext _dbContext, ILogger _logger) : base(_dbContext, _logger)
        {

        }
    }
}
