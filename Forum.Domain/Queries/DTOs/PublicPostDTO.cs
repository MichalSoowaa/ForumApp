
namespace Forum.Domain.Queries.DTOs
{
	public sealed record PublicPostDTO(long Id, string Title, string Content, string Author, DateTime CreationDate);
}
