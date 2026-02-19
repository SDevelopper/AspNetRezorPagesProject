using AspNetRezorPagesProject.Models.ViewsModels;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace AspNetRezorPagesProject.Services.Services
{
    public class AuthCookieService : IAuthCookieService
    {
        public async Task SignInAsync(HttpContext httpContext, int userId)
        {
            var claims = new List<Claim>{
                new (ClaimTypes.NameIdentifier, userId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false,
                IssuedUtc = DateTimeOffset.UtcNow,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                AllowRefresh = true
            };

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                claimsPrincipal, 
                authProperties);
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
