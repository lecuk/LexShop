namespace LexShop.Model
{
	public class UserAuth
	{
		public long UserId { get; set; }
		public User User { get; set; }

		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }
	}
}
