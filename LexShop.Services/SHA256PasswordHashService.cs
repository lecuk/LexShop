using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LexShop.Services
{
	public class SHA256PasswordHashService : IPasswordHashService
	{
		private readonly SHA256 sha;
		private Encoding encoding;

		public SHA256PasswordHashService()
		{
			sha = SHA256.Create();
			sha.Initialize();

			encoding = Encoding.ASCII;
		}

		public string HashPassword(string password)
		{
			byte[] input = encoding.GetBytes(password);
			byte[] output = sha.ComputeHash(input, 0, input.Length);
			string hashWithLines = BitConverter.ToString(output);
			string hash = hashWithLines.Replace("-", "").ToLower();
			return hash;
		}
	}
}
