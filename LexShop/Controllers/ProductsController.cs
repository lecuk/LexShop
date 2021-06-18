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
    public class ProductsController : Controller
    {
        private readonly LexShopContext _context;

        public ProductsController(LexShopContext context)
        {
            _context = context;
        }
		
        public async Task<IActionResult> View(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			Product product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
