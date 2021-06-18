using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LexShop.Model;

namespace LexShop
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddDbContext<LexShopContext>(optionsBuilder =>
			{
				string connection = Configuration.GetConnectionString("LexShopDB");
				optionsBuilder.UseSqlServer(connection);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/home/error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "categories",
					template: "/categories",
					defaults: new { controller = "Categories", action = "Index" });

				routes.MapRoute(
					name: "category",
					template: "/categories/{id}",
					defaults: new { controller = "Categories", action = "View", id = String.Empty });

				routes.MapRoute(
					name: "product",
					template: "/products/{id}",
					defaults: new { controller = "Products", action = "View", id = String.Empty });

				routes.MapRoute(
					name: "home",
					template: "/",
					defaults: new { controller = "Home", action = "Index" });
			});
		}
	}
}
