using Forum.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ForumTicketDbContext _context;

        public UsersRepository(ForumTicketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> VerifyUserLoginAsync(string email, string password)
        {
            return await _context.Users.AnyAsync(x => x.Email == email && x.Password == password);
        }
    }
}
