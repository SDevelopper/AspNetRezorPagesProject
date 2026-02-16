using AspNetRezorPagesProject.Models.DTO;
using FluentValidation;
namespace AspNetRezorPagesProject.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator() 
        {

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters")
                .MaximumLength(50)
                .WithMessage("Password cannot exceed 50 characters");
        }
    }
}
