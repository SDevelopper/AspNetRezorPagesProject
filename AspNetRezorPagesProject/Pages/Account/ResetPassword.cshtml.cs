using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AspNetRezorPagesProject.Pages.Account
{
    public class ResetPasswordModel(

        IAuthService authService
        ) : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public ResetPasswordDto Input { get; set; } = new ();
        public void OnGet(){ }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid){
                return Page();
            }
            if(!await authService.ResetPasswordAsync(Input))
            {
                ModelState.AddModelError(string.Empty, "Не удалось сбросить пароль." +
                    "Ссылка недействительна или устарела.");
                return Page();
            }

            TempData["StatusMessage"] = "Пароль изменен! " +
                "Используйте новый пароль чтобы войти.";

            return RedirectToPage("Login");
        }
    }
}
