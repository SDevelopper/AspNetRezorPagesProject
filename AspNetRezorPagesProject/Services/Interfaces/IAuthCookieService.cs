using AspNetRezorPagesProject.Models.ViewsModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IAuthCookieService
    {
        Task SignInAsync(HttpContext httpContext, AuthUser user);
        Task SignOutAsync(HttpContext httpContext);
    }
}
