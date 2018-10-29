namespace TechTest.Persistence.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using TechTest.Domain.Entities;

	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products");

			builder.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(40);

			builder.Property(e => e.UnitPrice)
				.HasColumnType("money")
				.HasDefaultValueSql("((0))");

			builder.HasOne(d => d.Supplier)
				.WithMany(p => p.Products)
				.HasForeignKey(d => d.SupplierId)
				.HasConstraintName("FK_Products_Suppliers");
		}
	}
}
