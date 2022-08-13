using Microsoft.AspNetCore.Mvc;
using RS.Identity.API.Models.InputModels;
using RS.Identity.API.Models.Interfaces;
using System.Threading.Tasks;

namespace RS.Identity.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : MainController
    {
        private readonly IJwtServices _jwtServices;

        public AuthController(IJwtServices jwtServices)
        {
            _jwtServices = jwtServices;
        }

        [HttpPost("new-account")]
        public async Task<IActionResult> Register(UserRegistrationInputModel userRegistration)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            return CustomResponse(await _jwtServices.UserRegistration(userRegistration));
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(UserLoginInputModel userLogin)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _jwtServices.UserLoginAsync(userLogin));
        }
    }
}