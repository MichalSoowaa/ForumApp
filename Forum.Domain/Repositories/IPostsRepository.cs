
using Forum.Domain.Commands;
using Forum.Domain.Entities;

namespace Forum.Domain.Repositories
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task AddPostAsync(Post post);
    }
}
