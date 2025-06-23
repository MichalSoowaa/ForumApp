using Forum.Domain.Queries.DTOs;
using MediatR;

namespace Forum.Domain.Queries.User.VerifyUserLogin
{
    public sealed record VerifyUserLoginQuery(string Email, string Password) : IRequest<UserPublicDTO>;
}
