using AspNetRezorPagesProject.Data;
using AspNetRezorPagesProject.Models.ViewsModels;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetRezorPagesProject.Services.Services
{
    public class DashboardService(AppDbContext dbContext) : IDashboardService
    {
        public async Task<UserViewModel?> GetUserDataAsync(int userId)
        {
            
            return await dbContext.Users
                .AsNoTracking()
                .Where(x => x.Id == userId)
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                })
                .FirstOrDefaultAsync();
        }
        //public async Task<UserViewModel> GetUserDataAsync(int userId)
        //{

        //    var user = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync( x =>
        //    x.Id == userId);

        //    if (user == null)
        //        throw new InvalidOperationException("User not found");

        //    return new UserViewModel
        //    {
        //        Id = userId,
        //        Name = user.Name,
        //        Email = user.Email
        //    };
        //}
    }
}
