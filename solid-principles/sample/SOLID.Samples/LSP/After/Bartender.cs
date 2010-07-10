namespace SOLID.Samples.Tests.LSP.After
{
	public class Bartender
	{
		public bool CanPersonDrinkAlcohol(Person person)
		{
			return person.CanDrinkAlcohol;
		}
	}
}