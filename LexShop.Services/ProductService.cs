using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LexShop.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LexShop.Services
{
	public class ProductService : IProductService
	{
		public readonly LexShopContext context;

		public ProductService(LexShopContext context)
		{
			this.context = context;
		}

		public IEnumerable<Product> GetAllProductsInCategory(long categoryId)
		{
			return GetAllProductsInCategoryAsync(categoryId).Result;
		}

		public async Task<IEnumerable<Product>> GetAllProductsInCategoryAsync(long categoryId)
		{
			return await context.Product
				.Where(product => product.CategoryId == categoryId)
				.ToListAsync();
		}

		public Product GetProduct(long id)
		{
			return GetProductAsync(id).Result;
		}

		public async Task<Product> GetProductAsync(long id)
		{
			return await context.Product
				.Include(product => product.Vendor)
				.Include(product => product.Category)
				.FirstOrDefaultAsync(product => product.Id == id);
		}

		public bool ProductExists(long id)
		{
			return context.Product
				.Any(product => product.Id == id);
		}

		public long GetProductCount()
		{
			return context.Product
				.Count();
		}
	}
}
