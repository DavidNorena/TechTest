namespace TechTest.Application.Orders.Commands
{
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using TechTest.Application.Orders.Models;
	using TechTest.Domain.Entities;
	using TechTest.Domain.Enumerations;
	using TechTest.Persistence;

	public class CreateOrderCommandHandler : MediatR.IRequestHandler<CreateOrderCommand, OrderModel>
	{
		private readonly TechTestDbContext dbContext;

		public CreateOrderCommandHandler(TechTestDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<OrderModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var def = new OrderModel
			{
				Success = false,
				DispatchPlace = "",
				InvoiceId = 0,
				TotalPrice = 0
			};

			var product = await dbContext.Products
				.Include(p => p.Supplier)
				.FirstOrDefaultAsync(p => p.Id == request.ProductId);

			var order = await dbContext.Orders
				.FirstOrDefaultAsync(
				o => o.Id == request.OrderId && o.Status == OrderStatus.Pending);

			if (product == null || order == null)
				return def;

			// crear factura
			var invoice = new Invoice
			{
				Date = DateTime.Now,
				OrderId = order.Id,
				Status = InvoiceStatus.Created
			};

			order.Invoice = invoice;

			// order.OrderDetails.Add(new OrderDetail
			order.OrderDetails = new OrderDetail
			{
				ProductId = request.ProductId,
				Quantity = request.Quantity,
				UnitPrice = product.UnitPrice
			};

			order.Status = OrderStatus.Confirmed;
			await dbContext.SaveChangesAsync();

			return new OrderModel
			{
				Success = true,
				DispatchPlace = product.Supplier.City,
				InvoiceId = invoice.Id,
				TotalPrice = product.UnitPrice * request.Quantity
			};

		}
	}
}
