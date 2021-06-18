using Microsoft.EntityFrameworkCore;
using LexShop.Model;

namespace LexShop.Model
{
	public class LexShopContext : DbContext
	{
		public DbSet<Person> Person { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Vendor> Vendor { get; set; }
		public DbSet<PaymentMethod> PaymentMethod { get; set; }
		public DbSet<Purchase> Purchase { get; set; }

		public LexShopContext(DbContextOptions<LexShopContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Category>(entity =>
			{
				entity.HasKey(category => category.Id);
				entity
					.HasOne(c => c.ParentCategory)
					.WithMany(c => c.ChildCategories)
					.IsRequired(false);
			});
		}
	}
}
