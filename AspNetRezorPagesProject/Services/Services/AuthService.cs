using AspNetRezorPagesProject.Data;
using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Models.ViewModels;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using AspNetRezorPagesProject.Models.Entity;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;


namespace AspNetRezorPagesProject.Services.Services
{
    public class AuthService(
        AppDbContext dbContext,
        IConfiguration configuration,
        IEmailService emailService,
        IMapper mapper
        ) : IAuthService
    {
        public async Task<UserViewModel?> RegisterAsync(RegisterDto registerDto)
        {
            var normalizedEmail = registerDto.Email!
                .Trim()
                .ToLowerInvariant();

            if (await dbContext.Users.AnyAsync(x =>
            x.Email == normalizedEmail)) { return null; }

            var user = new User
            {
                Name = registerDto.Name!.Trim(),
                Email = normalizedEmail,
                HashPassword = BCryptNet.HashPassword(registerDto.Password, 12)
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return mapper.Map<UserViewModel>(user);
        }       

        public async Task<UserViewModel?> LoginAsync(LoginDto loginDto)
        {
            var normalizedEmail = loginDto.Email!
                .Trim()
                .ToLowerInvariant();

            var user = await dbContext.Users
                .FirstOrDefaultAsync(x => x.Email == normalizedEmail);

            if (user == null || !BCryptNet.Verify(loginDto.Password, user.HashPassword))
            { return null; }

            return mapper.Map<UserViewModel>(user);
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null){
                return true;
            }

            byte[] tokenBytes = RandomNumberGenerator.GetBytes(32);
            string token = WebEncoders.Base64UrlEncode(tokenBytes);

            string tokenHash = ComputeSha256Hash(token);

            user.Token = tokenHash;
            user.TokenExpiration = DateTime.UtcNow.AddHours(1);

            await dbContext.SaveChangesAsync();

            string baseUrl = configuration["AppSettings:BaseUrl"]!;
            string resetLink = $"{baseUrl}/Account/ResetPassword?token=" +
                $"{Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";

            await emailService.SendPasswordResetEmailAsync(user.Email, resetLink);

            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto resetDto)
        {
            if (string.IsNullOrEmpty(resetDto.Token) || string.IsNullOrEmpty(resetDto.Email))
            {
                return false;
            }

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == resetDto.Email);

            if (user == null) { return false;}

            string TokenHash = ComputeSha256Hash(resetDto.Token);

            if (user.Token != TokenHash || user.TokenExpiration <= DateTime.UtcNow){
                return false;
            }

            user.HashPassword = BCryptNet.HashPassword(resetDto.NewPassword, 12);

            user.Token = null;
            user.TokenExpiration = null;

            await dbContext.SaveChangesAsync();

            return true;
        }

        private static string ComputeSha256Hash(string rawData) =>
            Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(rawData)));
    }
}
