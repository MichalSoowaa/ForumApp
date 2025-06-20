using Forum.Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Domain.Entities
{
	[Table("Answers", Schema = "Forum")]
	public class Answer : BaseEntity
	{
		[Required]
		public string Content { get; protected set; }

		[Required]
		public DateTime CreationDate { get; protected set; }

		[Required]
		public DateTime EditDate { get; protected set; }

		[Required]
		public long PostId { get; protected set; }
		public Post Post { get; protected set; }

		[Required]
		public long AuthorId { get; protected set; }
		public User Author { get; protected set; }

		protected Answer() { }

		public Answer(string content, long postId, long authorId)
		{
			Content = content;
			PostId = postId;
			AuthorId = authorId;
			CreationDate = DateTime.Now;
			EditDate = DateTime.Now;
		}
	}
}
