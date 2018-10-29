namespace TechTest.Application.Orders.Models
{
	public class OrderModel
	{
		public bool Success { get; set; }
		public int InvoiceId { get; set; }
		public string DispatchPlace { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
