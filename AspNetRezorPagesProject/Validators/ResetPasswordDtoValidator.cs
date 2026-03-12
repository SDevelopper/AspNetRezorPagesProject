using AspNetRezorPagesProject.Models.DTO;
using FluentValidation;

namespace AspNetRezorPagesProject.Validators
{
    public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator()
        {
            RuleFor(x => x.Token).NotEmpty();

            RuleFor(x => x.NewPassword)
               .NotEmpty()
               .WithMessage("The field is required")
               .MinimumLength(8)
               .WithMessage("Password must be at least 8 characters")
               .MaximumLength(50)
               .WithMessage("Password cannot exceed 50 characters");



            RuleFor(x => x.ConfirmPassword)
               .NotEmpty()
               .WithMessage("The field is required")
               .Equal(x => x.NewPassword)
               .WithMessage("Passwords do not match");
        }
    }
}
