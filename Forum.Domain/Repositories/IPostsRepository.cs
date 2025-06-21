
using Forum.Domain.Entities;

namespace Forum.Domain.Repositories
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
    }
}
