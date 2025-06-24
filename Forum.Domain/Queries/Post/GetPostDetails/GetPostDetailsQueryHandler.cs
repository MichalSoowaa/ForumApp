using Forum.Domain.Entities;
using Forum.Domain.Queries.DTOs;
using Forum.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Queries.Post.GetPostDetails
{
    public class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, PostDetailsDTO>
    {
        private readonly IPostsRepository _postsRepository;

        public GetPostDetailsQueryHandler(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public async Task<PostDetailsDTO> Handle(GetPostDetailsQuery query, CancellationToken cancellation)
        {
            var post = await _postsRepository.GetPostAsync(query.Id);

            if (post == null)
                throw new Exception("Post not found");

            var answersDTO = (post.Answers ?? Enumerable.Empty<Answer>())
                .Select(a =>
                    new AnswerDetailsDTO(a.Content, a.Author.Username, a.CreationDate))
                .ToList();

            return new PostDetailsDTO(
                post.Id,
                post.Title,
                post.Content,
                post.Author?.Username ?? "Anonimowy",
                post.CreationDate,
                answersDTO);
        }
    }
}
