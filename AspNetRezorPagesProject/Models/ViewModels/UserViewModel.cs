using System.ComponentModel.DataAnnotations;

namespace AspNetRezorPagesProject.Models.ViewsModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
