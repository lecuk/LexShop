using LexShop.Model;
using LexShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexShop.Controllers
{
	public class ControllerBase : Controller
	{
		protected readonly IUserService userService;

		public ControllerBase(IUserService userService)
		{
			this.userService = userService;
		}

		protected long? LoggedInUserId
		{
			get
			{
				if (User.Identity.IsAuthenticated)
				{
					if (Int64.TryParse(User.Identity.Name, out long id))
					{
						return id;
					}
				}

				return null;
			}
		}

		protected User GetLoggedInUser()
		{
			if (LoggedInUserId == null)
			{
				return null;
			}
			
			return userService.FindUser(LoggedInUserId.Value);
		}
	}
}
