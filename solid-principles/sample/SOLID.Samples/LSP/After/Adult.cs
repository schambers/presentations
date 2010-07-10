namespace SOLID.Samples.Tests.LSP.After
{
	public class Adult : Person
	{
		public override bool CanDrinkAlcohol
		{
			get { return true; }
		}

		public override bool ShouldDrinkMilk
		{
			get { return false; }
		}
	}
}