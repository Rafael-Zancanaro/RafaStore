using Microsoft.AspNetCore.Http;
using RS.Web.MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RS.Web.MVC.Services
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _acessor;

        public AspNetUser(IHttpContextAccessor acessor)
            => _acessor = acessor;

        public string Name => _acessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated()
            => _acessor.HttpContext.User.Identity.IsAuthenticated;

        public Guid GetUserId()
            => IsAuthenticated() ? Guid.Parse(_acessor.HttpContext.User.GetId()) : Guid.Empty;

        public string GetUserEmail()
            => IsAuthenticated() ? _acessor.HttpContext.User.GetEmail() : "";

        public string GetUserToken()
            => IsAuthenticated() ? _acessor.HttpContext.User.GetToken() : "";

        public bool OwnRole(string role)
            => _acessor.HttpContext.User.IsInRole(role);

        public IEnumerable<Claim> GetClaims()
            =>_acessor.HttpContext.User.Claims;

        public HttpContext GetHttpContext()
            => _acessor.HttpContext;
    }

    public static class ClaimsPrincipalExtentions
    {
        public static string GetId(this ClaimsPrincipal principal)
            => principal == null
                ? throw new ArgumentNullException(nameof(principal))
                : principal.FindFirst("sub")?.Value;

        public static string GetEmail(this ClaimsPrincipal principal)
            => principal == null
                ? throw new ArgumentNullException(nameof(principal))
                : principal.FindFirst("email")?.Value;

        public static string GetToken(this ClaimsPrincipal principal)
            => principal == null
                ? throw new ArgumentNullException(nameof(principal))
                : principal.FindFirst("JWT")?.Value;
    }
}