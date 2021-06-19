using LexShop.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LexShop.Services
{
	public interface IProductService
	{
		bool ProductExists(long id);

		Product GetProduct(long id);
		Task<Product> GetProductAsync(long id);

		IEnumerable<Product> GetAllProductsInCategory(long categoryId);
		Task<IEnumerable<Product>> GetAllProductsInCategoryAsync(long categoryId);

		long GetProductCount();
	}
}
