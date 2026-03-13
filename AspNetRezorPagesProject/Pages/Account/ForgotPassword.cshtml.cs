using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AspNetRezorPagesProject.Pages.Account
{
    public class ForgotPasswordModel(
        IAuthService authService
        ) : PageModel
    {
        [BindProperty]

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Введите корректный формат почты")]
        public string Email { get; set; } = string.Empty;
        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) {
                return Page();
            }
            await authService.ForgotPasswordAsync(Email);         
            return RedirectToPage("/ForgotPasswordConfirmation");
        }

    }
}
