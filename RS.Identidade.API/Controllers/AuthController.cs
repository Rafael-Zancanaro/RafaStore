using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RS.Identidade.API.Models;
using System.Threading.Tasks;

namespace RS.Identidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new IdentityUser
            {
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            return result.Succeeded
                    ? Ok()
                    : BadRequest();
        }
    }
}
