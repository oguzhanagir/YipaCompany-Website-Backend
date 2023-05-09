using Microsoft.Extensions.Logging;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(YipaDbContext _dbContext, ILogger _logger) : base(_dbContext, _logger)
        {

        }
    }
}
