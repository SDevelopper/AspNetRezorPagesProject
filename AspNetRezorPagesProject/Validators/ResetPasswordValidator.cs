using AspNetRezorPagesProject.Models.DTO;
using FluentValidation;

namespace AspNetRezorPagesProject.Validators
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("Введите новый пароль")
                .MinimumLength(8)
                .WithMessage("Минимум 8 символов")
                .MaximumLength(50)
                .WithMessage("Максимум 50 символов");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("Пароли не совпадают");
        }
    }
}
