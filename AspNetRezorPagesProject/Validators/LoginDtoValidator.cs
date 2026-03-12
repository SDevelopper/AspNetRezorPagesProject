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
                .WithMessage("The field is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("The field is required");
        }
    }
}
