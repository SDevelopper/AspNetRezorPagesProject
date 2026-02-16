using AspNetRezorPagesProject.Models.DTO;
using FluentValidation;

namespace AspNetRezorPagesProject.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Length(2, 35)
                .WithMessage("Name must be between 2 and 35 characters");

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


            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Confirm Password is required")
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match");
        }
    }
}
