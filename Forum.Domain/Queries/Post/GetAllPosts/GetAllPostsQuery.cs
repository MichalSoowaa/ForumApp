using Forum.Domain.Queries.DTOs;
using MediatR;

namespace Forum.Domain.Queries.Post.GetAllPosts
{
    public sealed record GetAllPostsQuery : IRequest<List<PostDTO>>;
}
