using MediatR;

namespace Forum.Domain.Queries.User.VerifyUserLogin
{
    public sealed record VerifyUserLoginQuery(string Email, string Password) : IRequest<bool>;
}
