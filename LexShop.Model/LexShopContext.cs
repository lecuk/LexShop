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
					.HasForeignKey(c => c.ParentCategoryId)
					.IsRequired(false);
			});

			builder.Entity<Product>(entity =>
			{
				entity.HasKey(product => product.Id);

				entity
					.HasOne(product => product.Vendor)
					.WithMany()
					.HasForeignKey(product => product.VendorId)
					.IsRequired(true);

				entity
					.HasOne(product => product.Category)
					.WithMany()
					.HasForeignKey(product => product.CategoryId)
					.IsRequired(true);
			});
		}
	}
}
