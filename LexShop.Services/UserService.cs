using System;
using System.Threading.Tasks;
using LexShop.Model;

namespace LexShop.Services
{
	public class UserService : IUserService
	{
		private readonly LexShopContext context;

		public UserService(LexShopContext context)
		{
			this.context = context;
		}

		public void EditUser(long userId, User newUserData)
		{
			newUserData.Id = userId;
			context.Users.Update(newUserData);
			context.SaveChanges(); 
		}

		public async Task EditUserAsync(long userId, User newUserData)
		{
			newUserData.Id = userId;
			context.Users.Update(newUserData);
			await context.SaveChangesAsync();
		}

		public User FindUser(long id)
		{
			return context.Users.Find(id);
		}

		public Task<User> FindUserAsync(long id)
		{
			return context.Users.FindAsync(id);
		}
	}
}
