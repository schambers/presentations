
namespace SOLID.Samples.SRP.After
{
	public class Person
	{
		public Person(string name, decimal accountBalance)
		{
			Name = name;
			Account = new Account(accountBalance);
		}

		public string Name { get; private set; }

		// Account implementation is now hidden behind
		// the Account class, although to consumers
		// nothing has changed

		private Account Account { get; set; }

		public decimal AvailableFunds
		{
			get { return Account.AvailableFunds; }
		}

		public decimal AccountBalance
		{
			get { return Account.Balance; }
		}

		public void DeductFromBalanceBy(decimal amountToDeduct)
		{
			Account.DeductFromBalanceBy(amountToDeduct);
		}
	}
}
