namespace TechTest.Application.Invoices.Models
{
	using System;
	using TechTest.Domain.Enumerations;

	public class InvoiceModel
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public decimal TotalPrice { get; set; }
		// public string BillingName { get; set; }
		public DateTime Date { get; set; }
		public InvoiceStatus Status { get; set; }
	}
}
