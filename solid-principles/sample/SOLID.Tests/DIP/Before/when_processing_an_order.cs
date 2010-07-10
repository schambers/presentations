using NUnit.Framework;
using SpecUnit;

namespace SOLID.Samples.Tests.DIP.Before
{
	[Concern("DIP"), TestFixture]
	public class when_processing_an_order : ContextSpecification
	{
		private OrderProcessor orderProcessor;
		private Order _order;

		protected override void Context()
		{
			orderProcessor = new OrderProcessor();
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
	}
}
