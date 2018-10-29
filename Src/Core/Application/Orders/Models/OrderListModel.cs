using System;

namespace TechTest.Application.Orders.Models
{
	public class ProductDetail
	{
		public string Name { get; set; }
		public decimal UnitPrice { get; set; }
	}

	public class OrderListModel
    {
		public DateTime OrderDate { get; set; }
		public int Quantity { get; set; }
		public int InvoiceId { get; set; }
		public string DispatchPlace { get; set; }
		public decimal TotalPrice { get; set; }
		public ProductDetail Product { get; set; }
	}
}
