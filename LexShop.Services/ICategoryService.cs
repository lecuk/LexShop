using LexShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexShop.Services
{
	public interface ICategoryService
	{
		bool CategoryExists(long id);

		Category GetCategory(long id);
		Task<Category> GetCategoryAsync(long id);

		IEnumerable<Category> GetAllCategoryAncestors(long id);
		Task<IEnumerable<Category>> GetAllCategoryAncestorsAsync(long id);

		IEnumerable<Category> GetAllRootCategories();
		Task<IEnumerable<Category>> GetAllRootCategoriesAsync();

		long GetCategoryCount();
	}
}
