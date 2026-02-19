using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Services.Interfaces;
using AspNetRezorPagesProject.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetRezorPagesProject.Pages.Auth
{
    public class LoginModel(IAuthService authService, IAuthCookieService cookieService) : PageModel
    {
        [BindProperty]
        public LoginDto LoginDto { get; set; } = new LoginDto();

        public void OnGet(){}
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            var userId = await authService.LoginAsync(LoginDto);

            if (userId == 0) { return Page(); }

            await cookieService.SignInAsync(HttpContext, userId);

            return RedirectToPage("/dashboard");
        }
    }
}
