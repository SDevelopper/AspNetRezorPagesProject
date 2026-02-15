using Microsoft.EntityFrameworkCore;
namespace AspNetRezorPagesProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
