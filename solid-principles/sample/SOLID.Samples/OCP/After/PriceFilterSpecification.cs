using System.Collections.Generic;

namespace SOLID.Samples.Tests.OCP.After
{
	public class PriceFilterSpecification : FilterSpecification
	{
		public PriceFilterSpecification(decimal price)
		{
			Price = price;
		}

		public decimal Price { get; private set; }

		public override IEnumerable<Product> Filter(IEnumerable<Product> products)
		{
			foreach (var product in products)
				if (product.Price == Price)
					yield return product;
		}
	}
}