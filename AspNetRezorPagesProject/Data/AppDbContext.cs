using AspNetRezorPagesProject.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace AspNetRezorPagesProject.Data
{
    public class AppDbContext(
        DbContextOptions<AppDbContext> options
        ) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
