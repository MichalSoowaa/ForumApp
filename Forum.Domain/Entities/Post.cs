using Forum.Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Domain.Entities
{
	[Table("Posts", Schema = "Forum")]
	public class Post : BaseEntity
	{
		[MaxLength(256)] [Required]
		public string Title { get; protected set; }

		[Required]
		public string Content {  get; protected set; }

		[Required]
		public DateTime CreationDate { get; protected set; }

		[Required]
		public DateTime EditDate { get; protected set; }

		[Required]
		public long AuthorId {  get; protected set; }
		public User Author { get; protected set; }

		protected Post() { }

		public Post(string title, string content, User author)
		{
			Title = title;
			Content = content;
			Author = author;
			CreationDate = DateTime.Now;
			EditDate = DateTime.Now;
		}
	}
}
