using AspNetRezorPagesProject.Data;
using AspNetRezorPagesProject.Models.ViewModels;
using AspNetRezorPagesProject.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
namespace AspNetRezorPagesProject.Services.Services
{
    public class DashboardService(
        AppDbContext dbContext,
        IMapper mapper
        ) : IDashboardService
    {
        public async Task<UserViewModel?> GetUserDataAsync(int Id)
        {
            return await dbContext.Users
                .AsNoTracking()
                .Where(x => x.Id == Id)
                .ProjectTo<UserViewModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
