
namespace TechTest.Application.Orders.Commands
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using TechTest.Application.Orders.Models;
	using TechTest.Domain.Entities;
	using TechTest.Domain.Enumerations;
	using TechTest.Persistence;

	public class CreatePreOrderCommandHandler : MediatR.IRequestHandler<CreatePreOrderCommand, PreOrderModel>
	{
		private readonly TechTestDbContext dbContext;

		public CreatePreOrderCommandHandler(TechTestDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<PreOrderModel> Handle(CreatePreOrderCommand request, CancellationToken cancellationToken)
		{
			var entity = new Order
			{
				OrderDate = DateTime.Now,
				Status = OrderStatus.Pending
			};
			dbContext.Orders.Add(entity);
			await dbContext.SaveChangesAsync();

			return new PreOrderModel
			{
				OrderId = entity.Id
			};
		}
	}
}
