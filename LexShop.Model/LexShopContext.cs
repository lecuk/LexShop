using System;
using Microsoft.EntityFrameworkCore;

namespace LexShop.Model
{
	public class LexShopContext : DbContext
	{
		public DbSet<Person> Person { get; set; }
	}
}
