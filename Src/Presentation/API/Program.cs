namespace TechTest.API
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;
	using System;
	using System.IO;
	using TechTest.Persistence;

	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				try
				{
					var context = scope.ServiceProvider.GetService<TechTestDbContext>();
					context.Database.Migrate();

					TechTestInitializer.Initialize(context);
				}
				catch (Exception ex)
				{
					var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while migrating or initializing the database.");
				}
			}

			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					var env = hostingContext.HostingEnvironment;
					config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
						  .AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true)
						  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
					config.AddEnvironmentVariables();
				})
				.UseStartup<Startup>();
	}
}
