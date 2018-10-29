namespace TechTest.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System.Threading.Tasks;
	using TechTest.Application.Orders.Commands;
	using TechTest.Application.Orders.Queries;

	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : BaseController
    {
		// GET: api/Orders
		[HttpGet]
		public async Task<IActionResult> GetAllOrders()
		{
			var orders = await Mediator.Send(new GetOrdersQuery());

			return CreatedAtAction("GetAllOrders", orders);
		}

		// POST: api/Orders/CreatePreOrder
		[HttpPost]
		[Route("CreatePreOrder")]
		public async Task<IActionResult> CreatePreOrder([FromBody] CreatePreOrderCommand command)
		{
			var preOrder = await Mediator.Send(command);

			return CreatedAtAction("Create", preOrder);
		}

		// POST: api/Orders/CreateOrder
		[HttpPost]
		[Route("CreateOrder")]
		public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
		{
			var order = await Mediator.Send(command);

			return CreatedAtAction("Create", order);
		}
	}
}
