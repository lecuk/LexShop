using LexShop.Model;
using LexShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexShop.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ICategoryService categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		// GET: categories
		public async Task<IActionResult> Index()
		{
			return View(await categoryService.GetAllRootCategoriesAsync());
		}

		// GET: categories/1
		public async Task<IActionResult> View(long? id)
		{
			if (id == null || !categoryService.CategoryExists(id.Value))
			{
				return NotFound();
			}

			Category category = await categoryService.GetCategoryAsync(id.Value);
			
			return View(category);
		}
	}
}
