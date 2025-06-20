using Forum.Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Domain.Entities
{
	[Table("Users", Schema = "Forum")]
	public class User : BaseEntity
	{
		[MaxLength(256)] [Required]
		public string Username { get; protected set; }

		[EmailAddress] [Required]
		public string Email { get; protected set; }

		[Required]
		public string Password { get; protected set; }

		[Required]
		public DateTime CreationDate { get; protected set; }

		protected User() {}

		public User(string username, string email, string password)
		{
			Username = username;
			Email = email;
			Password = password;
			CreationDate = DateTime.Now;
		}
	}
}
