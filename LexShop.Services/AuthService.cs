using LexShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexShop.Services
{
	public class AuthService : IAuthService
	{
		private readonly IPasswordHashService hashService;
		private readonly IUserService userService;
		private readonly LexShopContext context;

		public AuthService(LexShopContext context, IUserService userService, IPasswordHashService hashService)
		{
			this.hashService = hashService;
			this.context = context;
			this.userService = userService;
		}

		public long TryRegister(string email, string password)
		{
			UserAuth auth = context.Auths
				.Where(a => a.Email == email)
				.SingleOrDefault();

			if (auth != null)
			{
				throw new InvalidOperationException("Email already exists.");
			}

			string salt = "salt1234"; // TODO normal salt generation
			string fullPassword = $"{password}{salt}";
			string hash = hashService.HashPassword(fullPassword);

			User user = new User()
			{
				Email = email
			};

			auth = new UserAuth()
			{
				Email = email,
				PasswordSalt = salt,
				PasswordHash = hash
			};

			user.Auth = auth;
			auth.User = user;

			context.Users.Add(user);
			context.Auths.Add(auth);

			context.SaveChanges();

			return user.Id;
		}

		public User TryLogin(string email, string password)
		{
			UserAuth auth = context.Auths
				.Where(a => a.Email == email)
				.SingleOrDefault();
			
			if (auth != null)
			{
				string salt = auth.PasswordSalt;
				string fullPassword = $"{password}{salt}";
				string hash = hashService.HashPassword(fullPassword);

				if (hash == auth.PasswordHash)
				{
					return userService.FindUser(auth.UserId);
				}
			}

			throw new ArgumentException("Invalid email and/or password.");
		}
	}
}
