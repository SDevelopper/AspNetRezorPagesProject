using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Services.Interfaces;
using AspNetRezorPagesProject.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetRezorPagesProject.Pages.Auth
{
    public class RegisterModel(IAuthService authService, IAuthCookieService cookieService) : PageModel
    {
        [BindProperty]
        public RegisterDto RegisterDto { get; set; } = new RegisterDto();
        public void OnGet(){}

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid) return Page(); 

            int userId = await authService.RegisterAsync(RegisterDto);
            if (userId == 0) { return Page(); }

            await cookieService.SignInAsync(HttpContext, userId);

            return RedirectToPage("/dashboard");

        }
    }
}
