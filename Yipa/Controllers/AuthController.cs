using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Yipa.Business.Concrete;
using Yipa.Entities.Concrete;

namespace Yipa.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthManager _authManager;

        public AuthController(AuthManager authManager)
        {
            _authManager = authManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user =  _authManager.GetUserByEmailAndPasswordAsync(model.Email!, model.Password!);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return BadRequest();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Mail!),
                new Claim(ClaimTypes.Role, user.Role!.Name!)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Admin");
        }
    }
}
