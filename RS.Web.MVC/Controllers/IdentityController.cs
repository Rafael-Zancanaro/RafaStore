using Microsoft.AspNetCore.Mvc;
using RS.Web.MVC.Models;
using System.Threading.Tasks;

namespace RS.Web.MVC.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet("new-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("new-account")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if(!ModelState.IsValid) return View(registerUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid) return View(loginUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
