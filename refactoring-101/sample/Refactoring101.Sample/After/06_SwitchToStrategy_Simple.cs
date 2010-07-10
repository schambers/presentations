using System.Collections.Generic;

namespace Refactoring101.Sample.After
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
		private IDictionary<State, IShippingCalculation> ShippingCalculations { get; set; }

		public ShippingProcessor()
		{
			ShippingCalculations = new Dictionary<State, IShippingCalculation>
			{
				{ State.Alaska, new AlaskShippingCalculation() },
				{ State.NewYork, new NewYorkShippingCalculation() },
				{ State.Florida, new FloridaShippingCalculation() }
			};
		}

		public decimal CalculateShippingAmount(State shipToState)
		{
			return ShippingCalculations[shipToState].Calculate();
		}
	}

	public interface IShippingCalculation
	{
		decimal Calculate();
	}

	public class AlaskShippingCalculation : IShippingCalculation
	{
		public decimal Calculate()
		{
			return 15m;
		}
	}

	public class NewYorkShippingCalculation : IShippingCalculation
	{
		public decimal Calculate()
		{
			return 10m;
		}
	}

	public class FloridaShippingCalculation : IShippingCalculation
	{
		public decimal Calculate()
		{
			return 3m;
		}
	}
}
