using MediatR;

namespace Forum.Domain.Commands.Post.Create
{
    public sealed record CreateNewPostCommand(string Title, string Content, long userId) : IRequest<Result>;
}
