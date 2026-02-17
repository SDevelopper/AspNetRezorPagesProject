using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Models.Entity;
using AspNetRezorPagesProject.Models.ViewsModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthUser> RegisterAsync(RegisterDto registerDto);
        Task<AuthUser> LoginAsync(LoginDto loginDto);
    }
}
