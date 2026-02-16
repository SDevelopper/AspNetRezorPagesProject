using AspNetRezorPagesProject.Data;
using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Models.ViewsModels;
using AspNetRezorPagesProject.Services.Interfaces;

namespace AspNetRezorPagesProject.Services.Services
{
    public class AuthService(AppDbContext dbContext) : IAuthService
    {
        private readonly AppDbContext _dbContext = dbContext;
        Task<AuthUser> IAuthService.RegisterAsync(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthUser> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

    }
}
