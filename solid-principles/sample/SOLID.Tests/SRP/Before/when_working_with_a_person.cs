using System;
using NUnit.Framework;
using SOLID.Samples.SRP.Before;
using SpecUnit;

namespace SOLID.Samples.Tests.SRP.Before
{
	[TestFixture]
	public class when_working_with_a_person : ContextSpecification
	{
		private Person _person;
		private string _name = "Sean Chambers";
		private const decimal _accountBalance = 100m;

		protected override void Context()
		{
			_person = new Person(_name, _accountBalance);
		}

		[Observation, Test]
		public void can_get_persons_properties()
		{
			_person.Name.ShouldEqual(_name);
			_person.Balance.ShouldEqual(_accountBalance);
		}

		[Observation, Test]
		public void can_deduct_from_account_balance()
		{
			_person.DeductFromBalanceBy(70m);
			_person.Balance.ShouldEqual(30m);
		}

		[Observation, Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void cannot_deduct_more_from_account_then_is_available()
		{
			_person.DeductFromBalanceBy(105m);
		}

		[Observation, Test]
		public void should_always_have_at_least_ten_dollars_in_account()
		{
			_person.AvailableFunds.ShouldEqual(90m);
		}
	}
}