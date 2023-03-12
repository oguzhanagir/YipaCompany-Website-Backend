using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _commentManager;

        public CommentController(CommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AdminCommentList()
        {
            var commentList = _commentManager.GetAll();
            return View(commentList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _commentManager.AddComment(comment);
            return RedirectToAction("/");
        }

        public IActionResult GetCommentByBlog(int id)
        {
            var commentList = _commentManager.GetCommentsByBlog(id);
            return View(commentList);
        }

        public IActionResult DeleteComment(int id)
        {
            _commentManager.DeleteComment(id);
            return RedirectToAction("/");
        }

    }
}
