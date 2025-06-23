using Forum.Domain.Entities;


namespace Forum.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<User?> VerifyUserLoginAsync(string email, string password);
        Task<bool> IsUsernameAvailableAsync(string username);
        Task<bool> IsEmailAvailableAsync(string email);
        Task AddUserAsync(User user);
    }
}
