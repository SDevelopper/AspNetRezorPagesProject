namespace AspNetRezorPagesProject.Models.DTO
{
    public record RegisterDto
    {
        public string? Name { get; set; } 

        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}