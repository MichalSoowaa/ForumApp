using Forum.Domain.Queries.DTOs;
using MediatR;

namespace Forum.Domain.Queries.Post.GetPostDetails
{
    public sealed record GetPostDetailsQuery(long Id) : IRequest<PostDetailsDTO>;
}
