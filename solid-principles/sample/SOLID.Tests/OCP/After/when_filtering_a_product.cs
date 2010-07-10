using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SpecUnit;

namespace SOLID.Samples.Tests.OCP.After
{
	[TestFixture]
	public class when_filtering_a_product : ContextSpecification
	{
		private ProductFilter _productFilter;

		protected override void Context()
		{
			var product1 = new Mock<Product>();
			product1.SetupGet(x => x.Price).Returns(10m);
			product1.SetupGet(x => x.Color).Returns(Color.Green);

			var product2 = new Mock<Product>();
			product2.SetupGet(x => x.Price).Returns(20m);
			product2.SetupGet(x => x.Color).Returns(Color.Red);

			var products = new List<Product> {product1.Object, product2.Object};
			_productFilter = new ProductFilter(products);
		}

		[Observation, Test]
		public void can_filter_by_price()
		{
			var priceFilterSpecification = new PriceFilterSpecification(10m);

			_productFilter.FilterBy(priceFilterSpecification).Count().ShouldEqual(1);
		}

		[Observation, Test]
		public void can_filter_by_color()
		{
			var colorFilterSpecification = new ColorFilterSpecification(Color.Green);

			_productFilter.FilterBy(colorFilterSpecification).Count().ShouldEqual(1);
		}

		[Observation, Test]
		public void can_filter_by_size_and_color()
		{
			var colorPriceFilterSpecification = new ColorPriceFilterSpecification(Color.Green, 10m);

			_productFilter.FilterBy(colorPriceFilterSpecification).Count().ShouldEqual(1);
		}
	}
}