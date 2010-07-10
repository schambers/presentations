namespace SOLID.Samples.ISP.After
{
	public class Ant : IAnimal
	{

		string IAnimal.Feed()
		{
			return "ant fed";
		}
	}
}