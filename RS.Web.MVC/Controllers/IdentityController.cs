using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RS.Identity.API.Models.JwtToken;
using RS.Web.MVC.Models;
using RS.Web.MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RS.Web.MVC.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IAuthenticationApiService _authenticateService;

        public IdentityController(IAuthenticationApiService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpGet("new-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("new-account")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if(!ModelState.IsValid) 
                return View(registerUser);

            var response = await _authenticateService.Register(registerUser);

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
            if (!ModelState.IsValid) 
                return View(loginUser);

            var response = await _authenticateService.Login(loginUser);

            await Log_in(response.Result);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        private async Task Log_in(UserAswerLogin response)
        {
            var token = GetFormattedToken(response.AccessToken);

            var claims = new List<Claim>
            {
                new Claim("JWT", response.AccessToken)
            };
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        private static JwtSecurityToken GetFormattedToken(string token)
            => new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
    }
}
