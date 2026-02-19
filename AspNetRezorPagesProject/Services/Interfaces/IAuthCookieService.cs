using AspNetRezorPagesProject.Models.ViewsModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IAuthCookieService
    {
        Task SignInAsync(HttpContext httpContext, int userId);
        Task SignOutAsync(HttpContext httpContext);
    }
}
