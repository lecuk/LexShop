namespace LexShop.ViewModels
{
	public class RegisterViewModel : ViewModelBase
	{
		public string FirstName { get; set; }
		public string PhoneNumber { get; set; }
		public string City { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }
		public string PasswordAgain { get; set; }
	}
}
