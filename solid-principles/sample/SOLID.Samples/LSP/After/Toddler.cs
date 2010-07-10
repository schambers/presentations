namespace SOLID.Samples.Tests.LSP.After
{
	public class Toddler : Person
	{
		public override bool CanDrinkAlcohol
		{
			get { return false; }
		}

		public override bool ShouldDrinkMilk
		{
			get { return true; }
		}
	}
}