using System.ComponentModel.DataAnnotations;

namespace AspNetRezorPagesProject.Models.ViewsModels
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
