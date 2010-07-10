using System.Collections.Generic;
using System.Linq;

namespace Refactoring101.Sample.After.IoC
{
	// Ninject Configuration
	//	public class ShippingModule : NinjectModule
	//	{
	//		public override void Load()
	//		{
	//			Bind<IShippingCalculation>().To<AlaskaShippingCalculation>();
	//			Bind<IShippingCalculation>().To<NewYorkShippingCalculation>();
	//			Bind<IShippingCalculation>().To<FloridaShippingCalculation>();
	//		}
	//	}

	public enum State
	{
		Alaska,
		NewYork,
		Florida
	}

	public class ClientCode
	{
		[Inject]
		public IShippingProcessor ShippingProcessor { get; set; }

		public decimal CalculateShipping()
		{
			return ShippingProcessor.CalculateShippingAmount(State.Alaska);
		}
	}

	public interface IShippingProcessor
	{
		decimal CalculateShippingAmount(State state);
	}

	public class ShippingProcessor : IShippingProcessor
	{
		private IDictionary<State, IShippingCalculation> ShippingCalculations { get; set; }

		public ShippingProcessor(IEnumerable<IShippingCalculation> shippingCalculations)
		{
			ShippingCalculations = shippingCalculations.ToDictionary(calc => calc.State);
		}

		public decimal CalculateShippingAmount(State shipToState)
		{
			return ShippingCalculations[shipToState].Calculate();
		}
	}

	public interface IShippingCalculation
	{
		State State { get; }
		decimal Calculate();
	}

	public class AlaskShippingCalculation : IShippingCalculation
	{
		public State State { get { return State.Alaska; } }

		public decimal Calculate()
		{
			return 15m;
		}
	}

	public class NewYorkShippingCalculation : IShippingCalculation
	{
		public State State { get { return State.NewYork; } }

		public decimal Calculate()
		{
			return 10m;
		}
	}

	public class FloridaShippingCalculation : IShippingCalculation
	{
		public State State { get { return State.Florida; } }

		public decimal Calculate()
		{
			return 3m;
		}
	}
}
