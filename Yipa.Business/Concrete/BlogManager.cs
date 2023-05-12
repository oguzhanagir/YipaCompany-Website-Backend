using FluentValidation;
using FluentValidation.Results;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class BlogManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Blog> _validator;

        public BlogManager(IUnitOfWork unitOfWork, IValidator<Blog> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<Blog> GetAll()
        {
            var blogList = _unitOfWork.Blogs.GetAll(x=>x.Category!);
            return blogList;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            var blogList = await _unitOfWork.Blogs.GetAllAsync();
            return blogList;
        }

        public ValidationResult AddBlog(Blog blog)
        {
            var validation = _validator.Validate(blog);

            if (validation.IsValid)
            {
                _unitOfWork.Blogs.Add(blog);
                _unitOfWork.Save();
            }
            return validation;
        }

        public void UpdateBlog(Blog p)
        {
            var blog = _unitOfWork.Blogs.Find(x => x.Id == p.Id);
            if (blog != null)
            {
                blog!.Title = p.Title;
                blog.Content = p.Content;
                blog.PublicDate = p.PublicDate;
                blog.ImagePath = p.ImagePath;
                blog.Id = p.Id;
                blog.UserId = p.UserId;

                _unitOfWork.Blogs.Update(blog);
                _unitOfWork.Save();
            }
        }

        public void DeleteBlog(int id)
        {
            var blog = _unitOfWork.Blogs.Find(x => x.Id == id);

            if (blog != null)
            {
                _unitOfWork.Blogs.Remove(blog);
                _unitOfWork.Save();
            }
        }

        public List<Blog> GetBlogId(int id)
        {
            var blog = _unitOfWork.Blogs.List(x => x.Id == id);
            return blog!;
        }

        public IEnumerable<Blog> LatesBlogList()
        {
            var latestBlogs = _unitOfWork.Blogs.GetAll().OrderByDescending(b => b.PublicDate).Take(5);
            return latestBlogs;
        }

        public IEnumerable<Blog> GetPopularBlogs()
        {
            var latestBlogs = _unitOfWork.Blogs.GetAll().OrderByDescending(b => b.PublicDate).Take(2); // Popular Blog Listelenecektir.
            return latestBlogs;
        }


    
        public IEnumerable<User> GetUsers()
        {
            var userList = _unitOfWork.Users.GetAll();
            return userList;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categoryList = _unitOfWork.Categories.GetAll();
            return categoryList;
        }


    }
}
