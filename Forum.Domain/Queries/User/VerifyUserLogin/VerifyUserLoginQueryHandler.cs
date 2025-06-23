using Forum.Domain.Queries.DTOs;
using Forum.Domain.Repositories;
using MediatR;

namespace Forum.Domain.Queries.User.VerifyUserLogin
{
    public class VerifyUserLoginQueryHandler : IRequestHandler<VerifyUserLoginQuery, UserPublicDTO>
    {
        private readonly IUsersRepository _repository;

        public VerifyUserLoginQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserPublicDTO?> Handle(VerifyUserLoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.VerifyUserLoginAsync(query.Email, query.Password);

            if (user == null)
                return null;

            return new UserPublicDTO(user.Id, user.Username);
        }
    }
}
