
namespace Forum.Domain.Queries.DTOs
{
	public sealed record PostPublic(long Id, string Title, string Content, string Author, DateTime CreationDate);
}
