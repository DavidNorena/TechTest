namespace TechTest.Persistence
{
	using System.Collections.Generic;
	using System.Linq;
	using TechTest.Domain.Entities;

	public class TechTestInitializer
	{
		private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();
		private readonly Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();

		public static void Initialize(TechTestDbContext context)
		{
			var initializer = new TechTestInitializer();
			initializer.SeedEverything(context);
		}

		public void SeedEverything(TechTestDbContext context)
		{
			context.Database.EnsureCreated();

			if (context.Products.Any()) // TODO:
			{
				return; // Db has been seeded
			}

			SeedSuppliers(context);

			SeedProducts(context);
		}

		public void SeedSuppliers(TechTestDbContext context)
		{
			Suppliers.Add(1, new Supplier { Name = "Supplier 1", City = "Bogota", Phone = "305 7969992" });
			Suppliers.Add(2, new Supplier { Name = "Supplier 2", City = "Cali", Phone = "305 7969992" });
			Suppliers.Add(3, new Supplier { Name = "Supplier 3", City = "Barranquilla", Phone = "305 7969992" });

			foreach (var product in Products.Values)
			{
				context.Products.Add(product);
			}

			context.SaveChanges();
		}

		public void SeedProducts(TechTestDbContext context)
		{
			Products.Add(1, new Product { Name = "Product 1", UnitPrice = 25000, Supplier = Suppliers[1] });
			Products.Add(2, new Product { Name = "Product 2", UnitPrice = 20000, Supplier = Suppliers[2] });
			Products.Add(3, new Product { Name = "Product 3", UnitPrice = 10000, Supplier = Suppliers[3] });

			foreach (var product in Products.Values)
			{
				context.Products.Add(product);
			}

			context.SaveChanges();
		}
	}
}
