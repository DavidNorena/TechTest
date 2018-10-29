namespace TechTest.Application.Orders.Queries
{
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using TechTest.Application.Orders.Models;
	using TechTest.Domain.Enumerations;
	using TechTest.Persistence;

	public class GetOrdersQueryHandler : MediatR.IRequestHandler<GetOrdersQuery, IEnumerable<OrderListModel>>
	{
		private readonly TechTestDbContext dbContext;

		public GetOrdersQueryHandler(TechTestDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<IEnumerable<OrderListModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
		{
			return await dbContext.Orders
				.Where(e => e.Status == OrderStatus.Confirmed)
				.OrderByDescending(p => p.OrderDate)
				.Select(e => new OrderListModel
				{
					InvoiceId = e.Invoice.Id,
					OrderDate = e.OrderDate,
					Quantity = e.OrderDetails.Quantity,
					DispatchPlace = e.OrderDetails.Product.Supplier.City,
					Product = new ProductDetail
					{
						Name = e.OrderDetails.Product.Name,
						UnitPrice = e.OrderDetails.Product.UnitPrice,
					},
					TotalPrice = e.OrderDetails.Quantity * e.OrderDetails.UnitPrice
				})
				.ToListAsync(cancellationToken);

		}
	}
}
