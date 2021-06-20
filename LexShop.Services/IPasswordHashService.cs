using System;
using System.Collections.Generic;
using System.Text;

namespace LexShop.Services
{
	public interface IPasswordHashService
	{
		string HashPassword(string password);
	}
}
