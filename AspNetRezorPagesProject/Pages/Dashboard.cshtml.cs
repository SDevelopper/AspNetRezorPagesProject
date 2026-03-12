using AspNetRezorPagesProject.Models.ViewModels;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AspNetRezorPagesProject.Pages
{
    [Authorize]
    public class DashboardModel(IDashboardService dashboardService) : PageModel
    {
        public UserViewModel? UserViewModel { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userClaimId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userClaimId == null || !int.TryParse(userClaimId.Value, out int userId))
            {
                return RedirectToPage("/Auth/Login");
            }

            var data = await dashboardService.GetUserDataAsync(userId);
            if (data == null)
            {             
                return RedirectToPage("/Account/Login");
            }

            UserViewModel = data;
            return Page();
        }
    }
}
