using FluentValidation;
using Forum.Domain.Entities;
using Forum.Domain.Repositories;
using MediatR;

namespace Forum.Domain.Commands.User.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IUsersRepository _repository;
        private readonly IValidator<RegisterUserCommand> _validator;

        public RegisterUserCommandHandler(IUsersRepository repository, IValidator<RegisterUserCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            var user = new Forum.Domain.Entities.User(command.Username, command.Email, command.Password);

            await _repository.AddUserAsync(user);

            return Result.Ok();
        }
    }
}
