namespace Refactoring101.Sample.Before
{
	public class ClientCode
	{
		public decimal CalculateShipping()
		{
			ShippingProcessor shippingProcessor = new ShippingProcessor();
			return shippingProcessor.CalculateShippingAmount(State.Alaska);
		}
	}

	public enum State
	{
		Alaska,
		NewYork,
		Florida
	}

	public class ShippingProcessor
	{
		public decimal CalculateShippingAmount(State shipToState)
		{
			switch (shipToState)
			{
				case State.Alaska:
					return GetAlaskaShippingAmount();
				case State.NewYork:
					return GetNewYorkShippingAmount();
				case State.Florida:
					return GetFloridaShippingAmount();
				default:
					return 0m;
			}
		}

		private decimal GetAlaskaShippingAmount()
		{
			return 15m;
		}

		private decimal GetNewYorkShippingAmount()
		{
			return 10m;
		}

		private decimal GetFloridaShippingAmount()
		{
			return 3m;
		}
	}
}
