using System.ComponentModel.DataAnnotations;

namespace AspNetRezorPagesProject.Models.DTO
{
    public class LoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
