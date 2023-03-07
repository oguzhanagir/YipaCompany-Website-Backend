﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.DataAccess.Concrete
{
    public class NewsletterRepository : GenericRepository<Newsletter>, INewsletterRepository
    {
        public NewsletterRepository(YipaDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {

        }
    }
}