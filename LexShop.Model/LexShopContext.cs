using Microsoft.EntityFrameworkCore;
using LexShop.Model;

namespace LexShop.Model
{
	public class LexShopContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<UserAuth> Auths { get; set; }
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

			builder.Entity<User>(entity =>
			{
				entity.HasKey(user => user.Id);

				entity
					.HasOne(user => user.Auth)
					.WithOne(auth => auth.User)
					.IsRequired(true);
			});

			builder.Entity<UserAuth>(entity =>
			{
				entity.HasKey(auth => auth.UserId);

				entity
					.HasOne(auth => auth.User)
					.WithOne(user => user.Auth)
					.HasForeignKey((UserAuth auth) => auth.UserId)
					.IsRequired(true);

				entity
					.HasIndex(auth => auth.Email)
					.IsUnique();

				entity
					.Property(auth => auth.Email)
					.HasMaxLength(256);
			});
		}
	}
}
