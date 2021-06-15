using Microsoft.EntityFrameworkCore;
using LexShop.Model;

namespace LexShop.Model
{
	public class LexShopContext : DbContext
	{
		public DbSet<Person> Person { get; set; }

		public LexShopContext(DbContextOptions<LexShopContext> options) : base(options)
		{
		}
	}
}
