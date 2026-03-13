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
                .WithMessage("Поле обязательно для заполнения")
                .MinimumLength(2)
                .WithMessage("Имя должно содержать минимум 2 символа")
                .MaximumLength(35)
                .WithMessage("Имя не должно превышать 35 символов");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Поле обязательно для заполнения")
                .EmailAddress()
                .WithMessage("Введите корректный адрес электронной почты");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Поле обязательно для заполнения")
                .MinimumLength(8)
                .WithMessage("Пароль должен содержать минимум 8 символов")
                .MaximumLength(50)
                .WithMessage("Пароль не должен превышать 50 символов");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Поле обязательно для заполнения")
                .Equal(x => x.Password)
                .WithMessage("Пароли не совпадают");
        }
    }
}
