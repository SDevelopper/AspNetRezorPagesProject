using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Models.Entity;
using AspNetRezorPagesProject.Models.ViewsModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegisterAsync(RegisterDto registerDto);
        Task<int> LoginAsync(LoginDto loginDto);
    }
}
