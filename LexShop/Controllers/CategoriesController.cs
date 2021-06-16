using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LexShop.Model;

namespace LexShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly LexShopContext _context;

        public CategoriesController(LexShopContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Categories/5
		[Route("Categories/{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
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
