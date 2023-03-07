using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class CommentManager
    {
        private readonly IValidator<Comment> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IValidator<Comment> validator, IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Comment> GetAll()
        {
            var commenList = _unitOfWork.Comments.GetAll();
            return commenList;
        }

        public ValidationResult AddComment(Comment comment)
        {
            var validation = _validator.Validate(comment);

            if (validation.IsValid)
            {
                _unitOfWork.Comments.Add(comment);
                _unitOfWork.Save();
            }
            return validation;
        }

     
        public void DeleteComment(int id)
        {
            var comment = _unitOfWork.Comments.Find(x => x.Id == id);

            if (comment != null)
            {
                _unitOfWork.Comments.Remove(comment);
                _unitOfWork.Save();
            }
        }

        public Comment GetCommentsByBlog(int blogId)
        {
            var commentList = _unitOfWork.Comments.Find(x => x.Blog!.Id == blogId);
            return commentList!;
        }
    }
}
