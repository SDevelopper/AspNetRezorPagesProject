using AspNetRezorPagesProject.Models.ViewModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IAuthCookieService
    {
        Task SignInAsync(HttpContext httpContext, UserViewModel user);
        Task SignOutAsync(HttpContext httpContext);
    }
}
