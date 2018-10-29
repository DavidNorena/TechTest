namespace TechTest.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System.Threading.Tasks;
	using TechTest.Application.Products.Queries;

	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : BaseController
	{
		// GET: api/Products
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await Mediator.Send(new GetAllProductsQuery()));
		}
	}
}
