using System;
using System.Collections.Generic;
using TechTest.Domain.Enumerations;

namespace TechTest.Domain.Entities
{
	public class Order
	{
		//public Order()
		//{
		//	OrderDetails = new HashSet<OrderDetail>();
		//}

		public int Id { get; set; }
		// public int CustomerId { get; set; }
		public DateTime OrderDate { get; set; }
		public int InvoiceId { get; set; }
		public OrderStatus Status { get; set; }

		//public Customer Customer { get; set; }
		public Invoice Invoice { get; set; }
		// public ICollection<OrderDetail> OrderDetails { get; set; }
		public OrderDetail OrderDetails { get; set; }
	}
}
