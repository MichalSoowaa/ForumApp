using FluentValidation;
using Forum.Domain.Repositories;

namespace Forum.Domain.Commands.User.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUsersRepository _repository;

        public RegisterUserCommandValidator(IUsersRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Nazwa użytkownika nie może być pusta")
                .MaximumLength(256).WithMessage("Maksymalna liczba znaków to 256")
                .MustAsync(IsUniqueUsername).WithMessage("Ta nazwa użytkownika jest zajęta");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email nie może być pusty")
                .EmailAddress().WithMessage("Niepoprawny adres email")
                .MustAsync(IsUniqueEmail).WithMessage("Ten email jest zajęty");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Hasło nie może być puste")
                .MinimumLength(8).WithMessage("Hasło musi posiadać minimum 8 znaków");

            RuleFor(x => x.ConfirmedPassword)
                .NotEmpty().WithMessage("Musisz potwierdzić hasło")
                .Equal(x => x.Password).WithMessage("Hasła nie są identyczne");
		}

		private async Task<bool> IsUniqueUsername(string username, CancellationToken token)
		    => await _repository.IsUsernameAvailableAsync(username);

        private async Task<bool> IsUniqueEmail(string email, CancellationToken token)
            => await _repository.IsEmailAvailableAsync(email);
	}
}
