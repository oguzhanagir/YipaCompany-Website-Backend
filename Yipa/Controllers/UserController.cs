using Microsoft.AspNetCore.Mvc;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminUserList()
        {
            var userList = _userManager.GetAll();
            return View(userList);
        }

        public IActionResult DeleteUser(int id)
        {
            _userManager.DeleteUser(id);
            return RedirectToAction("AdminUserList");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = _userManager.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            _userManager.UpdateUser(user);
            return RedirectToAction("AdminUserList");
        }

        public IActionResult GetUserDetails(int id)
        {
            var user = _userManager.GetUserById(id);
            return View(user);
        }

    }
}
