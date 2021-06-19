using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LexShop.Model;
using LexShop.Services;

namespace LexShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
		
        public async Task<IActionResult> View(long? id)
        {
            if (id == null || !productService.ProductExists(id.Value))
            {
                return NotFound();
            }

			Product product = await productService.GetProductAsync(id.Value);

            return View(product);
        }
    }
}
