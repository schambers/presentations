using System.Collections.Generic;

namespace SOLID.Samples.Tests.OCP.After
{
	public class Consumer
	{
		private ProductFilter Filter;

		public Consumer()
		{
			Filter = new ProductFilter(new List<Product>());
		}

		public void FilterProductsByColor()
		{
			var colorFilteredProducts = Filter.FilterBy(new ColorFilterSpecification(Color.Blue));

			var priceFilteredProducts = Filter.FilterBy(new PriceFilterSpecification(10));

			var priceAndColorFilteredProducts = Filter.FilterBy(new ColorPriceFilterSpecification(Color.Blue, 10));
		}
	}
}