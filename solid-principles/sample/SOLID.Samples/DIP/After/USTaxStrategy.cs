namespace SOLID.Samples.Tests.DIP.After
{
	public class USTaxStrategy : ITaxStrategy
	{
		public decimal GetTax()
		{
			return 1m;
		}
	}
}