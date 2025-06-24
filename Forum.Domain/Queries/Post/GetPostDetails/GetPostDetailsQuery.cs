using Forum.Domain.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Queries.Post.GetPostDetails
{
    public sealed record GetPostDetailsQuery(long Id) : IRequest<PostDetailsDTO>;
}
