namespace TechTest.Persistence.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using TechTest.Domain.Entities;

	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders");

			//builder.HasOne(d => d.Customer)
			//	.WithMany(p => p.Orders)
			//	.HasForeignKey(d => d.CustomerId)
			//	.HasConstraintName("FK_Orders_Customers");

			builder.HasOne(d => d.OrderDetails)
				.WithOne(p => p.Order)
				.HasForeignKey<OrderDetail>(d => d.OrderId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Order_Details_Orders");

			builder.HasOne(d => d.Invoice)
				.WithOne(p => p.Order)
				.HasForeignKey<Invoice>(e => e.OrderId)
				.HasConstraintName("FK_Orders_Invoices");
		}
	}
}
