using System.ComponentModel.DataAnnotations;

namespace Forum.Web.Models
{
	public class UserLoginViewModel
	{
		[Required(ErrorMessage = "Podaj adres email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Podaj hasło")]
		public string Password { get; set; }
	}
}
