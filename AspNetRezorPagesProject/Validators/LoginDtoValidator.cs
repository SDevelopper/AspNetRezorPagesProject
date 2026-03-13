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
                .WithMessage("Поле обязательно для заполнения")
                .EmailAddress()
                .WithMessage("Введите корректный адрес электронной почты");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Поле обязательно для заполнения");
        }
    }
}
