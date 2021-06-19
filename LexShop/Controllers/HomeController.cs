using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LexShop.ViewModels;
using LexShop.Services;

namespace LexShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductService productService;
		private readonly Random random;

		public HomeController(IProductService productService)
		{
			this.productService = productService;
			this.random = new Random();
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult RandomProduct()
		{
			long productCount = productService.GetProductCount();
			long randomProductId = random.Next((int)productCount) + 1;
			return Redirect($"~/products/{randomProductId}");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
