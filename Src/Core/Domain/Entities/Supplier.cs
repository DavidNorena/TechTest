
namespace TechTest.Domain.Entities
{
	using System.Collections.Generic;

	public class Supplier
	{
		public Supplier()
		{
			Products = new HashSet<Product>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }

		public ICollection<Product> Products { get; private set; }
	}
}
