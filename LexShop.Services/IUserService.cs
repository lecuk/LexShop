using LexShop.Model;
using System.Threading.Tasks;

namespace LexShop.Services
{
	public interface IUserService
	{
		User FindUser(long id);
		Task<User> FindUserAsync(long id);

		void EditUser(long userId, User newUserData);
		Task EditUserAsync(long userId, User newUserData);
	}
}
