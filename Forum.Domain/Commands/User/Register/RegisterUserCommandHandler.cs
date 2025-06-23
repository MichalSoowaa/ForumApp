using Forum.Domain.Entities;
using Forum.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Commands.User.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IUsersRepository _repository;

        public RegisterUserCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new RegisterUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            if (!await _repository.IsUsernameAvailableAsync(command.Username))
                return Result.Fail("Ta nazwa użytkownika jest zajęta");

            if (!await _repository.IsEmailAvailableAsync(command.Email))
                return Result.Fail("Ten email jest zajęty");

            var user = new Forum.Domain.Entities.User(command.Username, command.Email, command.Password);

            await _repository.AddUserAsync(user);

            return Result.Ok();
        }
    }
}
