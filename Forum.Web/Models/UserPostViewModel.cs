using System.ComponentModel.DataAnnotations;

namespace Forum.Web.Models
{
	public class UserPostViewModel
	{
		[Required(ErrorMessage = "Tytuł jest wymagany")]
		public string Title {  get; set; }

		[MinLength(100, ErrorMessage = "Minimalna liczba znaków wynosi 100")]
		public string Content { get; set; }
	}
}
