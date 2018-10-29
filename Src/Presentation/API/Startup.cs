namespace TechTest.API
{
	using MediatR;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using System.Reflection;
	using TechTest.Application.Products.Queries;
	using TechTest.Persistence;

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
			services.AddMediatR(typeof(GetAllProductsQuery).GetTypeInfo().Assembly);

			// Add DbContext using SQL Server Provider
			services.AddDbContext<TechTestDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("TechTestDatabase")));

			services.AddCors();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseCors(builder =>
			{
				builder.AllowAnyHeader();
				builder.AllowAnyMethod();
				builder.AllowAnyOrigin();
			});

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});
		}
	}
}
