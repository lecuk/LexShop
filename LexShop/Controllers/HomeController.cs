using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LexShop.ViewModels;
using LexShop.Services;
using LexShop.Model;

namespace LexShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILuckyService luckyService;
		private readonly Random random;

		public HomeController(ILuckyService luckyService)
		{
			this.luckyService = luckyService;
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

		public async Task<IActionResult> RandomProduct()
		{
			Product product = await luckyService.GetRandomProductAsync();
			return Redirect($"~/products/{product.Id}");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
