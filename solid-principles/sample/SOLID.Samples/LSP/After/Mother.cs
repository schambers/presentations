namespace SOLID.Samples.Tests.LSP.After
{
	public class Mother
	{
		public bool ShouldGiveBottleOfMilkTo(Person person)
		{
			return person.ShouldDrinkMilk;
		}
	}
}