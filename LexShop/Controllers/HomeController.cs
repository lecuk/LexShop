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
	public class HomeController : ControllerBase
	{
		protected readonly ILuckyService luckyService;
		protected readonly Random random;

		public HomeController(ILuckyService luckyService, IUserService userService)
			: base(userService)
		{
			this.luckyService = luckyService;
			this.random = new Random();
		}

		public IActionResult Index()
		{
			return View(new ViewModelBase()
			{
				LoggedInUser = GetLoggedInUser()
			});
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View(new ViewModelBase()
			{
				LoggedInUser = GetLoggedInUser()
			});
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View(new ViewModelBase()
			{
				LoggedInUser = GetLoggedInUser()
			});
		}

		public IActionResult Privacy()
		{
			return View(new ViewModelBase()
			{
				LoggedInUser = GetLoggedInUser()
			});
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
