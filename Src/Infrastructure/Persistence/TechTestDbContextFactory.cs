namespace TechTest.Persistence
{
	using Microsoft.EntityFrameworkCore;
	using TechTest.Persistence.Infrastructure;

	public class TechTestDbContextFactory : DesignTimeDbContextFactoryBase<TechTestDbContext>
	{
		protected override TechTestDbContext CreateNewInstance(DbContextOptions<TechTestDbContext> options)
		{
			return new TechTestDbContext(options);
		}
	}
}
