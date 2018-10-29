namespace TechTest.Persistence
{
	using Microsoft.EntityFrameworkCore;
	using TechTest.Domain.Entities;
	using TechTest.Persistence.Configurations;

	public class TechTestDbContext : DbContext
	{
		public TechTestDbContext(DbContextOptions<TechTestDbContext> options)
			: base(options)
		{
		}

		// public DbSet<Customer> Customers { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// modelBuilder.ApplyConfiguration(new CustomerConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new SupplierConfiguration());
		}
	}
}
