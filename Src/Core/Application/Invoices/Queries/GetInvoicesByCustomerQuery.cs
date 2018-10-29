namespace TechTest.Application.Invoices.Queries
{
	using System.Collections.Generic;
	using TechTest.Application.Invoices.Models;

	public class GetInvoicesByCustomerQuery : MediatR.IRequest<IEnumerable<InvoiceModel>>
	{
		public int CustomerId { get; set; }
	}
}
