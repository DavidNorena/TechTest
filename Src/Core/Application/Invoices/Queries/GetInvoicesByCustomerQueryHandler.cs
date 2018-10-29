using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechTest.Application.Invoices.Models;
using TechTest.Persistence;

namespace TechTest.Application.Invoices.Queries
{
	public class GetInvoicesByCustomerQueryHandler : MediatR.IRequestHandler<GetInvoicesByCustomerQuery, IEnumerable<InvoiceModel>>
	{
		private readonly TechTestDbContext dbContext;

		public GetInvoicesByCustomerQueryHandler(TechTestDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<IEnumerable<InvoiceModel>> Handle(GetInvoicesByCustomerQuery request, CancellationToken cancellationToken)
		{
			return await dbContext.Invoices
				.Select(i => new InvoiceModel
				{
					Id = i.Id,
					Date = i.Date,
					OrderId = i.OrderId,
					// BillingName = i.Order.Customer.Name,
					Status = i.Status,
					TotalPrice = i.Order.OrderDetails.Sum(d => d.Quantity * d.UnitPrice)
				})
				.OrderByDescending(p => p.Date)
				.ToListAsync(cancellationToken);
		}
	}
}
