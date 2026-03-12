using AspNetRezorPagesProject.Models.ViewModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<UserViewModel?> GetUserDataAsync(int Id);
    }
}
