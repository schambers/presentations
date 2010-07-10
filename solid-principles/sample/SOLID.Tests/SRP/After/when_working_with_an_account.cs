using System;
using NUnit.Framework;
using SOLID.Samples.SRP.After;
using SpecUnit;

namespace SOLID.Samples.Tests.SRP.After
{
	[Concern("Account"), TestFixture]
	public class when_working_with_an_account : ContextSpecification
	{
		private Account _account;
		private const decimal _accountBalance = 100m;

		protected override void Context()
		{
			_account = new Account(_accountBalance);
		}

		[Observation, Test]
		public void can_deduct_from_account_balance()
		{
			_account.DeductFromBalanceBy(70m);
			_account.Balance.ShouldEqual(30m);
		}

		[Observation, Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void cannot_deduct_more_from_account_then_is_available()
		{
			_account.DeductFromBalanceBy(105m);
		}

		[Observation, Test]
		public void should_always_have_at_least_ten_dollars_in_account()
		{
			_account.AvailableFunds.ShouldEqual(90m);
		}
	}
}
