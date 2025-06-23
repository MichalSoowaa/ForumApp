using MediatR;

namespace Forum.Domain.Commands.User.Register
{
    public sealed record RegisterUserCommand(string Username, string Email, string Password, string ConfirmedPassword) : IRequest<Result>;
}
