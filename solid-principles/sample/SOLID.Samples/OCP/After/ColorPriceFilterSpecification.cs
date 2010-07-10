using System.Collections.Generic;
using System.Linq;

namespace SOLID.Samples.Tests.OCP.After
{
	public class ColorPriceFilterSpecification : FilterSpecification
	{
		public ColorPriceFilterSpecification(Color color, decimal price)
		{
			ColorFilterSpecification = new ColorFilterSpecification(color);
			PriceFilterSpecification = new PriceFilterSpecification(price);
		}

		private ColorFilterSpecification ColorFilterSpecification { get; set; }
		private PriceFilterSpecification PriceFilterSpecification { get; set; }

		public override IEnumerable<Product> Filter(IEnumerable<Product> products)
		{
			var matchedColorProducts = ColorFilterSpecification.Filter(products);
			var matchedPriceProducts = PriceFilterSpecification.Filter(products);

			List<Product> matchedProducts = new List<Product>(matchedColorProducts.Concat(matchedPriceProducts).Distinct());

			return matchedProducts;
		}
	}
}