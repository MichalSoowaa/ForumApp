using System.ComponentModel.DataAnnotations;

namespace Forum.Web.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Podaj nazwę")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Podaj adres email")]
		[EmailAddress(ErrorMessage = "Niepoprawny adres email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Podaj hasło")]
		public string Password { get; set; }

		public string ConfirmedPassword { get; set; }
	}
}
