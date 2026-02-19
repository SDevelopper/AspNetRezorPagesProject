using AspNetRezorPagesProject.Models.ViewsModels;

namespace AspNetRezorPagesProject.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<UserViewModel> GetUserDataAsync(int userId);
    }
}
