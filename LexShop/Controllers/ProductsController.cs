using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LexShop.Model;
using LexShop.Services;
using Microsoft.AspNetCore.Authorization;
using LexShop.ViewModels;

namespace LexShop.Controllers
{
    public class ProductsController : ControllerBase
	{
		protected readonly IProductService productService;

        public ProductsController(IProductService productService, IUserService userService)
			: base(userService)
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

			return View(new ProductViewModel()
			{
				Product = product,
				LoggedInUser = GetLoggedInUser()
			});
        }

		[Authorize]
		public async Task<IActionResult> Purchase(long? id)
		{
			Product product = await productService.GetProductAsync(id.Value);

			return View(new ProductPurchaseViewModel()
			{
				ProductId = id.Value,
				Quantity = 1,
				LoggedInUser = GetLoggedInUser()
			});
		}

		[HttpPost]
		public async Task<IActionResult> Purchase(ProductPurchaseViewModel purchase)
		{
			return Redirect($"~/products/{purchase.ProductId}");
		}
	}
}
