using Forum.Domain.Repositories;
using MediatR;

namespace Forum.Domain.Queries.User.VerifyUserLogin
{
    public class VerifyUserLoginQueryHandler : IRequestHandler<VerifyUserLoginQuery, bool>
    {
        private readonly IUsersRepository _repository;

        public VerifyUserLoginQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(VerifyUserLoginQuery query, CancellationToken cancellationToken)
        {
            return await _repository.VerifyUserLoginAsync(query.Email, query.Password);
        }
    }
}
