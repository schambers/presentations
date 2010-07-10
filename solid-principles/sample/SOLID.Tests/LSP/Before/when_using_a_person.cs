using NUnit.Framework;
using SpecUnit;

namespace SOLID.Samples.Tests.LSP.Before
{
	[Concern("LSP"), TestFixture]
	public class when_using_a_person : ContextSpecification
	{
		[Observation, Test]
		public void adult_can_drink_alcohol()
		{
			var barTender = new Bartender();
			barTender.CanPersonDrinkAlcohol(new Adult());
		}

		[Observation, Test]
		public void toddler_can_get_bottle_of_milk()
		{
			var mother = new Mother();
			mother.ShouldGiveBottleOfMilkTo(new Toddler());
		}
	}
}
