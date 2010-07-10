using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SpecUnit;

namespace SOLID.Samples.Tests.OCP.Before
{
	[TestFixture]
	public class when_filtering_a_product : ContextSpecification
	{
		private ProductFilter _productFilter;

		protected override void Context()
		{
			// Setup Mock Product 1
			var product1 = new Mock<Product>();
			product1.SetupGet(x => x.Price).Returns(10m);
			product1.SetupGet(x => x.Color).Returns(Color.Green);

			// Setup Mock Product 2
			var product2 = new Mock<Product>();
			product2.SetupGet(x => x.Price).Returns(20m);
			product2.SetupGet(x => x.Color).Returns(Color.Red);

			// Create a ProductFilter, passing in our two Product Mocks within a List<Product>
			_productFilter = new ProductFilter(new List<Product> { product1.Object, product2.Object });
		}

		[Observation, Test]
		public void can_filter_by_price()
		{
			_productFilter.FilterByPrice(10m).Count().ShouldEqual(1);
		}

		[Observation, Test]
		public void can_filter_by_color()
		{
			_productFilter.FilterByColor(Color.Green).Count().ShouldEqual(1);
		}

		[Observation, Test]
		public void can_filter_by_size_and_color()
		{
			_productFilter.FilterBySizeAndPrice(Color.Green, 10m).Count().ShouldEqual(1);
			_productFilter.FilterBySizeAndPrice(Color.Red, 20m).Count().ShouldEqual(1);
			_productFilter.FilterBySizeAndPrice(Color.Green, 20m).Count().ShouldEqual(0);
		}
	}
}