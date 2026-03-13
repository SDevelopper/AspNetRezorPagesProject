using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Models.ViewModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserViewModel?> RegisterAsync(RegisterDto registerDto);
        Task<UserViewModel?> LoginAsync(LoginDto loginDto);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordDto resetDto);
    }
}
