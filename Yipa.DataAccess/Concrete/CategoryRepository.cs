using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(YipaDbContext _dbContext, ILogger _logger) : base(_dbContext, _logger)
        {

        }
    }
}
