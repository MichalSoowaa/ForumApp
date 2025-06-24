using Forum.Domain.Entities;
using Forum.Domain.Repositories;
using MediatR;

namespace Forum.Domain.Commands.Post.Create
{
    public class CreateNewPostCommandHandler : IRequestHandler<CreateNewPostCommand, Result>
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IUsersRepository _usersRepository;

        public CreateNewPostCommandHandler(IPostsRepository postsRepository, IUsersRepository usersRepository)
        {
            _postsRepository = postsRepository;
            _usersRepository = usersRepository;
        }

        public async Task<Result> Handle(CreateNewPostCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateNewPostCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            var user = await _usersRepository.GetUserByIdAsync(command.userId);

            if (user == null)
                return Result.Fail("Nie ma takiego użytkownika???");

            var post = new Forum.Domain.Entities.Post(command.Title, command.Content, user);

            await _postsRepository.AddPostAsync(post);

            return Result.Ok();
        }
    }
}
