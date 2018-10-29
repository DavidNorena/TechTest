namespace TechTest.Application.Products.Queries
{
	using System.Collections.Generic;
	using TechTest.Application.Products.Models;

	public class GetAllProductsQuery : MediatR.IRequest<IEnumerable<ProductModel>>
	{
    }
}
