using Microsoft.Extensions.Logging;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Concrete
{
    public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(YipaDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {

        }
    }
}
