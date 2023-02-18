using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;

namespace Yipa.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger _logger;
        private YipaDbContext _dbContext;

        public UnitOfWork(YipaDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("logs");
            _dbContext = dbContext;
            Abouts = new AboutRepository(_dbContext, _logger);
            Blogs = new BlogRepository(_dbContext, _logger);
            Comments = new CommentRepository(_dbContext, _logger);
            Contacts = new ContactRepository(_dbContext, _logger);
            Newsletters = new NewsletterRepository(_dbContext, _logger);
            Roles = new RoleRepository(_dbContext, _logger);
            SocialMedias = new SocialMediaRepository(_dbContext, _logger);
            Users = new UserRepository(_dbContext, _logger);
        }

        public IAboutRepository Abouts { get; private set; }

        public IBlogRepository Blogs { get; private set; }

        public ICommentRepository Comments { get; private set; }

        public IContactRepository Contacts { get; private set; }

        public INewsletterRepository Newsletters { get; private set; }

        public IRoleRepository Roles { get; private set; }

        public ISocialMediaRepository SocialMedias { get; private set; }

        public IUserRepository Users { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
