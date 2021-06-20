using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LexShop.Model;
using LexShop.Services;
using LexShop.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LexShop.Controllers
{
    public class UserController : ControllerBase
	{
		protected readonly IAuthService authService;

		public UserController(IAuthService authService, IUserService userService)
			: base(userService)
		{
			this.authService = authService;
		}

		public IActionResult Index()
        {
            return View(new ViewModelBase()
			{
				LoggedInUser = GetLoggedInUser()
			});
        }

		[HttpGet]
		public IActionResult Register()
		{
			return View(new RegisterViewModel()
			{
				LoggedInUser = GetLoggedInUser()
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel register)
		{
			if (register.Password != register.PasswordAgain)
			{
				ModelState.AddModelError("PasswordAgain", "Confirmed password doesn't match original password.");
			}

			if (ModelState.IsValid)
			{
				try
				{
					long userId = authService.TryRegister(register.Email, register.Password);
					User user = userService.FindUser(userId);

					user.FirstName = register.FirstName;
					user.Email = register.Email;
					user.PhoneNumber = register.PhoneNumber;
					user.City = register.City;

					await userService.EditUserAsync(userId, user);
					await Authenticate(userId);
					Redirect("~/user");
				}
				catch (InvalidOperationException)
				{
					ModelState.AddModelError("Email", "E-mail already exists.");
				}
				catch (Exception)
				{
					ModelState.AddModelError("", "Unknown error.");
				}
			}

			return View(new ViewModelBase()
			{
				LoggedInUser = GetLoggedInUser()
			});
		}

		[HttpGet]
		public IActionResult Login([FromQuery]string returnUrl)
		{
			ViewData["ReturnUrl"] = returnUrl;

			return View(new LoginViewModel()
			{
				LoggedInUser = GetLoggedInUser()
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel login)
		{
			if (ModelState.IsValid)
			{
				try
				{ 
					User user = authService.TryLogin(login.Email, login.Password);
					await Authenticate(user.Id);
					return Redirect(login.ReturnUrl ?? "~/");
				}
				catch (ArgumentException)
				{
					ModelState.AddModelError("", "Login and/or password don't match");
				}
			}

			return View(new ViewModelBase()
			{
				LoggedInUser = GetLoggedInUser()
			});
		}

		private async Task Authenticate(long userId)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString())
			};
			ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
		}
	}
}