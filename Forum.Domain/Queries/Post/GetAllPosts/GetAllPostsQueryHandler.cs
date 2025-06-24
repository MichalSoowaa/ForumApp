using Forum.Domain.Queries.DTOs;
using Forum.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Queries.Post.GetAllPosts
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<PublicPostDTO>>
    {
        private readonly IPostsRepository _repository;

        public GetAllPostsQueryHandler(IPostsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PublicPostDTO>> Handle(GetAllPostsQuery query, CancellationToken cancellationToken)
        {
            var posts = await _repository.GetAllPostsAsync();

            return posts.Select(post => new PublicPostDTO(
                post.Id,
                post.Title,
                post.Content,
                post.Author.Username,
                post.CreationDate)).ToList();
        }
    }
}
