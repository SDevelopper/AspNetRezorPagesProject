using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Services.Interfaces;
using AspNetRezorPagesProject.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetRezorPagesProject.Pages.Auth
{
    public class LoginModel(LoginDtoValidator validator, IAuthService authService) : PageModel
    {
        private readonly LoginDtoValidator _validator = validator;
        private readonly IAuthService _authService = authService;
        public LoginDto LoginDto { get; set; } = new LoginDto();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = _validator.Validate(LoginDto);

            if (!result.IsValid) { return Page();}

            var user = await _authService.LoginAsync(LoginDto);
            if (user == null) {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Page(); }

            return RedirectToPage("/dashboard");
        }
    }
}
