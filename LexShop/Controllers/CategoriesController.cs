using LexShop.Model;
using LexShop.Services;
using LexShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexShop.Controllers
{
	public class CategoriesController : ControllerBase
	{
		protected readonly ICategoryService categoryService;
		protected readonly IProductService productService;

		public CategoriesController(ICategoryService categoryService, IProductService productService, IUserService userService)
			: base(userService)
		{
			this.categoryService = categoryService;
			this.productService = productService;
		}

		// GET: categories
		public async Task<IActionResult> Index()
		{
			IEnumerable<Category> rootCategories = await categoryService.GetAllRootCategoriesAsync();
			return View(new CategoryListingViewModel()
			{
				RootCategories = rootCategories,
				LoggedInUser = GetLoggedInUser()
			});
		}

		// GET: categories/1
		public async Task<IActionResult> View([FromRoute]long? id)
		{
			if (id == null || !categoryService.CategoryExists(id.Value))
			{
				return NotFound();
			}

			Category category = await categoryService.GetCategoryAsync(id.Value);
			IEnumerable<Product> products = await productService.GetAllProductsInCategoryAsync(id.Value);
			IEnumerable<Category> ancestors = await categoryService.GetAllCategoryAncestorsAsync(id.Value);

			return View(new CategoryViewModel()
			{
				Category = category,
				Products = products,
				AncestorCategories = ancestors,
				LoggedInUser = GetLoggedInUser()
			});
		}
	}
}
