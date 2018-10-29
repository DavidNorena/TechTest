
//namespace TechTest.Application.Customers.Commands
//{
//	using System;
//	using System.Threading;
//	using System.Threading.Tasks;
//	using TechTest.Application.Commands.Models;
//	using TechTest.Domain.Entities;
//	using TechTest.Persistence;

//	public class CreateCustomerCommandHandler : MediatR.IRequestHandler<CreateCustomerCommand, CustomerModel>
//	{
//		private readonly TechTestDbContext dbContext;

//		public CreateCustomerCommandHandler(TechTestDbContext dbContext)
//		{
//			this.dbContext = dbContext;
//		}

//		public async Task<CustomerModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
//		{
//			Random rnd = new Random();
//			int rand = rnd.Next(1, 10000);
//			int rand2 = rnd.Next(1, 10000);

//			var entity = new Customer
//			{
//				Name = $"ANON-{rand}{rand2}"
//			};

//			dbContext.Customers.Add(entity);

//			await dbContext.SaveChangesAsync(cancellationToken);

//			return new CustomerModel
//			{
//				Id = entity.Id,
//				Name = entity.Name
//			};
//		}
//	}
//}
