using LexShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LexShop.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly LexShopContext _context;

		public CategoriesController(LexShopContext context)
		{
			_context = context;
		}

		// GET: categories
		public async Task<IActionResult> Index()
		{
			return View(await _context.Category.ToListAsync());
		}

		// GET: categories/1
		public async Task<IActionResult> View(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Category category = await _context.Category
				.FirstOrDefaultAsync(m => m.Id == id);

			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		private bool CategoryExists(long id)
		{
			return _context.Category.Any(e => e.Id == id);
		}
	}
}
