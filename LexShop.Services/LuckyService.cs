using System;
using System.Linq;
using System.Threading.Tasks;
using LexShop.Model;
using Microsoft.EntityFrameworkCore;

namespace LexShop.Services
{
	public class LuckyService : ILuckyService
	{
		public readonly LexShopContext context;

		public LuckyService(LexShopContext context)
		{
			this.context = context;
		}

		public Product GetRandomProduct()
		{
			return GetRandomProductAsync().Result;
		}

		public async Task<Product> GetRandomProductAsync()
		{
			return await context.Product
				.OrderBy(product => Guid.NewGuid())
				.FirstOrDefaultAsync();
		}
	}
}
