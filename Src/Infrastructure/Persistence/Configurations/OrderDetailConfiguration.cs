namespace TechTest.Persistence.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using TechTest.Domain.Entities;

	public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
	{
		public void Configure(EntityTypeBuilder<OrderDetail> builder)
		{
			builder.HasKey(e => new { e.OrderId, e.ProductId });

			builder.ToTable("OrderDetails");

			builder.Property(e => e.UnitPrice).HasColumnType("money");

			builder.HasOne(d => d.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Order_Details_Products");
		}
	}
}
