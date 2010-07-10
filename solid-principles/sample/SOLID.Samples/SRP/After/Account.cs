using System;

namespace SOLID.Samples.SRP.After
{
	public class Account
	{
		private const decimal _minimumRequiredBalance = 10m;

		public Account(decimal accountBalance)
		{
			Balance = accountBalance;
		}

		public decimal Balance { get; private set; }

		public decimal AvailableFunds
		{
			get { return Balance - _minimumRequiredBalance; }
		}

		public void DeductFromBalanceBy(decimal amountToDeduct)
		{
			if (amountToDeduct > Balance)
				throw new InvalidOperationException("Cannot deduct more than is available from Account");

			Balance -= amountToDeduct;
		}
	}
}