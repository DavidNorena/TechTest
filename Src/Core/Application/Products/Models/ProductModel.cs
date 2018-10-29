namespace TechTest.Application.Products.Models
{
	using System;
	using System.Linq.Expressions;
	using TechTest.Domain.Entities;

	public class ProductModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal UnitPrice { get; set; }
		public string SupplierName { get; set; }

		public static Expression<Func<Product, ProductModel>> Projection
		{
			get
			{
				return p => new ProductModel
				{
					Id = p.Id,
					Name = p.Name,
					UnitPrice = p.UnitPrice,
					SupplierName = p.Supplier.Name
				};
			}
		}
	}
}
