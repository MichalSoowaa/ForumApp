
namespace Forum.Domain.Queries.DTOs
{
	public sealed record PostDTO(long Id, string Title, string Content, long AuthorId);
}
