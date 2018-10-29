namespace TechTest.Application.Orders.Commands
{
	using TechTest.Application.Orders.Models;

	public class CreateOrderCommand : MediatR.IRequest<OrderModel>
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public short Quantity { get; set; }
	}
}
