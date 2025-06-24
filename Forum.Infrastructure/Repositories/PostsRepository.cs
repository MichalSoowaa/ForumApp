using Forum.Domain.Entities;
using Forum.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly ForumTicketDbContext _context;

        public PostsRepository(ForumTicketDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.Include(p => p.Author).ToListAsync();
        }

        public async Task AddPostAsync(Post post)
        {
           await _context.Posts.AddAsync(post);
           await _context.SaveChangesAsync();
        }

        public async Task<Post> GetPostAsync(long id)
        {
            return await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Answers)
                    .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
