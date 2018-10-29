namespace TechTest.Application.Orders.Queries
{
	using System.Collections.Generic;
	using TechTest.Application.Orders.Models;

	public class GetOrdersQuery : MediatR.IRequest<IEnumerable<OrderListModel>>
	{
	}
}
