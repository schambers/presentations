using NUnit.Framework;
using SOLID.Samples.SRP.After;
using SpecUnit;

namespace SOLID.Samples.Tests.SRP.After
{
	[Concern("Person"), TestFixture]
	public class when_working_with_a_person : ContextSpecification
	{
		private Person _person;
		private string _name = "Sean Chambers";
		private decimal _accountBalance = 100m;

		protected override void Context()
		{
			_person = new Person(_name, _accountBalance);
		}

		[Observation, Test]
		public void can_get_persons_properties()
		{
			_person.Name.ShouldEqual(_name);
			_person.AccountBalance.ShouldEqual(_accountBalance);
		}
	}
}