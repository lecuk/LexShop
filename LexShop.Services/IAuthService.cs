using LexShop.Model;

namespace LexShop.Services
{
	public interface IAuthService
	{
		long TryRegister(string email, string password);
		User TryLogin(string email, string password);
	}
}
