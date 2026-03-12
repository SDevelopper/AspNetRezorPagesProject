using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetRezorPagesProject.Pages.Account
{
    public class LogoutModel(IAuthCookieService cookieService) : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await cookieService.SignOutAsync(HttpContext);
            return RedirectToPage("/Account/Login");
        }
    }
}
