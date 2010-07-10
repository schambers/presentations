using System.Linq;

namespace SOLID.Samples.Tests.DIP.After
{
	#region Configuration

	// AppSettings Config
	// <appSettings>
	//   <add key="Country" value="UnitedStates" />
	// </appSettings>

	// IoC (Ninject) Config:
	//
	// in httmodule/app start:
	//		new StandardKernel(new TaxModule());
	//
	//
	//	public class TaxModule : NinjectModule
	//	{
	//		public override void Load()
	//		{
	//			Country country = (Country)Enum.Parse(typeof(Country), ConfigurationManager.AppSettings["Country"]);
	//
	//	 		if (country == Country.UnitedStates)
	//				Bind<ITaxStrategy>.To<USTaxStrategy>();
	//			else if (country == Country.UnitedKingdom)
	//				Bind<ITaxStrategy>.To<UKTaxStrategy>();
	//		}
	//	}

	#endregion

	public class OrderProcessor
	{
		private ITaxStrategy TaxStrategy { get; set; }

		public OrderProcessor(ITaxStrategy taxStrategy)
		{
			TaxStrategy = taxStrategy;
		}

		public void ProcessOrder(Order order)
		{
			order.Total = order.OrderLines.Sum(ol => ol.Amount);

			order.Tax += TaxStrategy.GetTax();

			order.GrandTotal = order.Total + order.Tax;
		}
	}

	public interface ITaxStrategy
	{
		decimal GetTax();
	}

	public enum Country
	{
		UnitedStates,
		UnitedKingdom
	}
}