namespace TechTest.Persistence.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using TechTest.Domain.Entities;

	public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
	{
		public void Configure(EntityTypeBuilder<Supplier> builder)
		{
			builder.ToTable("Suppliers");

			builder.Property(e => e.Name).HasMaxLength(30);

			builder.Property(e => e.City).HasMaxLength(20);

			builder.Property(e => e.Phone).HasMaxLength(24);
		}
	}
}
