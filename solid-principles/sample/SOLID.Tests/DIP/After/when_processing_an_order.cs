using Moq;
using NUnit.Framework;
using SpecUnit;

namespace SOLID.Samples.Tests.DIP.After
{
	[Concern("DIP"), TestFixture]
	public class when_processing_an_order : ContextSpecification
	{
		private OrderProcessor orderProcessor;
		private Order _order;
		private Mock<ITaxStrategy> _taxStrategyMock;

		protected override void Context()
		{
			_taxStrategyMock = new Mock<ITaxStrategy>();
			_taxStrategyMock.Setup(x => x.GetTax()).Returns(1m);

			orderProcessor = new OrderProcessor(_taxStrategyMock.Object);
			
			_order = new Order(new OrderLine("Widget", 10m), new OrderLine("Whizbanger", 20m));
		}

		protected override void Because()
		{
			orderProcessor.ProcessOrder(_order);
		}

		[Test]
		public void can_get_total_from_order()
		{
			_order.Total.ShouldEqual(30m);
		}

		[Test]
		public void can_get_tax_amount_from_order()
		{
			_order.Tax.ShouldEqual(1m);
		}

		[Test]
		public void can_get_grand_total_from_order()
		{
			_order.GrandTotal.ShouldEqual(31m);
		}

		[Test]
		public void tax_strategy_is_used_to_calculate_tax()
		{
			_taxStrategyMock.Verify(x => x.GetTax());
		}
	}
}
