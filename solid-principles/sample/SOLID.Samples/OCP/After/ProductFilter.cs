using System.Collections.Generic;

namespace SOLID.Samples.Tests.OCP.After
{
	public class ProductFilter
	{
		public ProductFilter(IEnumerable<Product> products)
		{
			Products = products;
		}

		public IEnumerable<Product> Products { get; private set; }

		public IEnumerable<Product> FilterBy(FilterSpecification filterSpecification)
		{
			return filterSpecification.Filter(Products);
		}
	}
}