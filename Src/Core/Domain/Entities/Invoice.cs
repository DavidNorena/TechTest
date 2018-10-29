namespace TechTest.Domain.Entities
{
	using System;
	using TechTest.Domain.Enumerations;

	public class Invoice
    {
		public int Id { get; set; }
		public int OrderId { get; set; }
		public DateTime Date { get; set; }
		public InvoiceStatus Status { get; set; }

		public Order Order { get; set; }
	}
}
