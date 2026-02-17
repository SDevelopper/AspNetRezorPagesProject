using AspNetRezorPagesProject.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace AspNetRezorPagesProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
