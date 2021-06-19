using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexShop.Model;
using Microsoft.EntityFrameworkCore;

namespace LexShop.Services
{
	public class CategoryService : ICategoryService
	{
		public readonly LexShopContext context;

		public CategoryService(LexShopContext context)
		{
			this.context = context;
		}

		public Category GetCategory(long id)
		{
			return GetCategoryAsync(id).Result;
		}

		public async Task<Category> GetCategoryAsync(long id)
		{
			return await context.Category
				.Include(category => category.ParentCategory)
				.Include(category => category.ChildCategories)
				.FirstOrDefaultAsync(category => category.Id == id);
		}

		public IEnumerable<Category> GetAllCategoryAncestors(long id)
		{
			return GetAllCategoryAncestorsAsync(id).Result;
		}

		public async Task<IEnumerable<Category>> GetAllCategoryAncestorsAsync(long id)
		{
			if (!CategoryExists(id))
			{
				return Enumerable.Empty<Category>();
			}

			LinkedList<Category> ancestors = new LinkedList<Category>();
			Category category = await GetCategoryAsync(id);

			while (category.ParentCategoryId != null)
			{
				category = await GetCategoryAsync(category.ParentCategoryId.Value);
				ancestors.AddFirst(category);
			}

			return ancestors;
		}

		public IEnumerable<Category> GetAllRootCategories()
		{
			return GetAllRootCategoriesAsync().Result;
		}

		public async Task<IEnumerable<Category>> GetAllRootCategoriesAsync()
		{
			return await context.Category
				.Where(category => category.ParentCategoryId == null)
				.ToListAsync();
		}

		public bool CategoryExists(long id)
		{
			return context.Category
				.Any(category => category.Id == id);
		}
	}
}
