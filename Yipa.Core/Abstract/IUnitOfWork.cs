using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yipa.Core.Abstract
{
    public interface IUnitOfWork
    {
        IAboutRepository Abouts{ get; }
        IBlogRepository Blogs { get; }
        ICommentRepository Comments { get; }
        IContactRepository Contacts { get; }
        INewsletterRepository Newsletters{ get; }
        IRoleRepository Roles { get; }
        ISocialMediaRepository SocialMedias { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }

        void Save();
    }
}
