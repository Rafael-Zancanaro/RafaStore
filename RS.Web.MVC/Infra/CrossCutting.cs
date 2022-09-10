using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RS.Web.MVC.Models.Interfaces;
using RS.Web.MVC.Models.Settings;
using RS.Web.MVC.Services;
using System;

namespace RS.Web.MVC.Infra
{
    public static class CrossCutting
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthenticationApiService, AuthenticationService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.Configure<IdentitySettings>(configuration.GetSection("IdentitySittings"));

            services.AddHttpClient<IAuthenticationApiService, AuthenticationService>(client => 
            client.BaseAddress = new Uri(configuration.GetSection("IdentitySittings")["UrlBase"]));

            return services;
        }
    }
}