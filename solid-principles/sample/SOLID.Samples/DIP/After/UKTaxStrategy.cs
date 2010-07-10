namespace SOLID.Samples.Tests.DIP.After
{
	public class UKTaxStrategy : ITaxStrategy
	{
		public decimal GetTax()
		{
			return 2m;
		}
	}
}