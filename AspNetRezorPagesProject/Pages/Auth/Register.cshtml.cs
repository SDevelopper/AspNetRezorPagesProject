using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Services.Interfaces;
using AspNetRezorPagesProject.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetRezorPagesProject.Pages.Auth
{
    public class RegisterModel(RegisterDtoValidator validator, IAuthService authService) : PageModel
    {
        private readonly RegisterDtoValidator _validator = validator;
        private readonly IAuthService _authService = authService;
        public RegisterDto RegisterDto { get; set; } = new RegisterDto();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            var result = _validator.Validate(RegisterDto);
            if (!result.IsValid) {
                foreach (var erroe in result.Errors)
                {
                    ModelState.AddModelError(erroe.PropertyName, erroe.ErrorMessage);
                }
                return Page(); 
            }

            var user = await _authService.RegisterAsync(RegisterDto);
            if (user == null) { return Page(); }

            return RedirectToPage("/dashboard");

        }
    }
}
