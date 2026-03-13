using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetRezorPagesProject.Pages.Account
{
    public class RegisterModel(
        IAuthService authService,
        IAuthCookieService cookieService
        ) : PageModel
    {
        [BindProperty]
        public RegisterDto Input { get; set; } = new();
        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = await authService.RegisterAsync(Input);
            if (user == null) { return Page(); }

            await cookieService.SignInAsync(HttpContext, user);

            return RedirectToPage("/dashboard");

        }
    }
}
