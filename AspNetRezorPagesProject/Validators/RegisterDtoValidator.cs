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
                .WithMessage("The field is required")
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters long")
                .MaximumLength(35)
                .WithMessage("Name cannot exceed 35 characters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("The field is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("The field is required")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters")
                .MaximumLength(50)
                .WithMessage("Password cannot exceed 50 characters");


            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("The field is required")
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match");
        }
    }
}
