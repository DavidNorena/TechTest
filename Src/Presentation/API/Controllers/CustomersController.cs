//namespace TechTest.API.Controllers
//{
//	using Microsoft.AspNetCore.Mvc;
//	using System.Threading.Tasks;
//	// using TechTest.Application.Customers.Commands;
//	// using TechTest.Application.Commands.Models;

//	[Route("api/[controller]")]
//	[ApiController]
//	public class CustomersController : BaseController
//	{
//		// POST: api/Customers
//		[HttpPost]
//		public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
//		{
//			var customer = await Mediator.Send(command);

//			return CreatedAtAction("Create", customer);
//		}
//	}
//}
