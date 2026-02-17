using AspNetRezorPagesProject.Data;
using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Models.ViewsModels;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using BCryptNet = BCrypt.Net.BCrypt;
using AspNetRezorPagesProject.Models.Entity;
using AspNetRezorPagesProject.Pages.Auth;


namespace AspNetRezorPagesProject.Services.Services
{
    public class AuthService(AppDbContext dbContext) : IAuthService
    {
        public async Task<AuthUser> RegisterAsync(RegisterDto registerDto)
        {
            if (await dbContext.Users.AnyAsync(x => x.Email == registerDto.Email))
                throw new InvalidOperationException("User with this email already exists.");


            string hashedPassword = BCryptNet.HashPassword(registerDto.Password, 12);

            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                HashPassword = hashedPassword,
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return new AuthUser { 
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<AuthUser> LoginAsync(LoginDto loginDto)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x =>
            x.Email == loginDto.Email);

            if (user == null || !(BCryptNet.Verify(loginDto.Password, user.HashPassword)))
                throw new InvalidOperationException("Invalid email or password");

            return new AuthUser
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
