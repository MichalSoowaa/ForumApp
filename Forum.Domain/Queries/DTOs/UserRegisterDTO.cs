

namespace Forum.Domain.Queries.DTOs
{
    public sealed record UserRegisterDTO(string Username, string Email, string Password, string ConfirmedPassword);
}
