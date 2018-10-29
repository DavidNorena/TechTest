namespace TechTest.Application.Products.Queries
{
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using TechTest.Application.Products.Models;
	using TechTest.Persistence;

	public class GetAllProductsQueryHandler : MediatR.IRequestHandler<GetAllProductsQuery, IEnumerable<ProductModel>>
	{
		private readonly TechTestDbContext _context;

		public GetAllProductsQueryHandler(TechTestDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			return await _context.Products
					.Select(ProductModel.Projection)
					.OrderBy(p => p.Name)
					.ToListAsync(cancellationToken);
		}
	}
}
