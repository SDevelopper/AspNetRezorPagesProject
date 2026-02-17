using System.ComponentModel.DataAnnotations;

namespace AspNetRezorPagesProject.Models.DTO
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
