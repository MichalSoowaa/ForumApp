using FluentValidation;

namespace Forum.Domain.Commands.User.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Nazwa użytkownika nie może być pusta")
                .MaximumLength(256).WithMessage("Maksymalna liczba znaków to 256");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email nie może być pusty")
                .EmailAddress().WithMessage("Niepoprawny adres email");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Hasło nie może być puste")
                .MinimumLength(8).WithMessage("Hasło musi posiadać minimum 8 znaków");

            RuleFor(x => x.ConfirmedPassword)
                .NotEmpty().WithMessage("Musisz potwierdzić hasło")
                .Equal(x => x.Password).WithMessage("Hasła nie są identyczne");
        }
    }
}
