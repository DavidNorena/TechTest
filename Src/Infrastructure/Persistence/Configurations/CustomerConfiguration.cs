//namespace TechTest.Persistence.Configurations
//{
//	using Microsoft.EntityFrameworkCore;
//	using Microsoft.EntityFrameworkCore.Metadata.Builders;
//	using TechTest.Domain.Entities;

//	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
//	{
//		public void Configure(EntityTypeBuilder<Customer> builder)
//		{
//			builder.ToTable("Customers");

//			builder.Property(e => e.Name)
//				.IsRequired()
//				.HasMaxLength(50);
//		}
//	}
//}
