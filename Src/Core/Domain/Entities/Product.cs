namespace TechTest.Domain.Entities
{
	using System.Collections.Generic;

	public class Product
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal UnitPrice { get; set; }
		public int SupplierId { get; set; }

		public Supplier Supplier { get; set; }
		public ICollection<OrderDetail> OrderDetails { get; private set; }
	}
}
