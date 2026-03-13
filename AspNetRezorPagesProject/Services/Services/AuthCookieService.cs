using AspNetRezorPagesProject.Models.ViewModels;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace AspNetRezorPagesProject.Services.Services
{
    public class AuthCookieService : IAuthCookieService
    {
        public async Task SignInAsync(
            HttpContext httpContext, 
            UserViewModel user
            )
        {
            var claims = new List<Claim>{
               new(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new(ClaimTypes.Name, user.Name),
               new(ClaimTypes.Email, user.Email),
           };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
                );

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true
            };

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties
                );
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
                );
        }
    }
}
