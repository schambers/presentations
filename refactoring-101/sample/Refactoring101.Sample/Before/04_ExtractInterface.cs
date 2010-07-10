namespace Refactoring101.Sample.Before
{
	// Dependency breaking technique

	public class CodeCampAttendee
	{
		public string Name { get; set; }
		public string Company { get; set; }
		public int RaffleNumber { get; set; }
		
		public bool IsPresenter { get; set; }
		public int NumberOfPresentations { get; set; }

		public void GivePresentationToClass(Session session)
		{
			// code
		}
	}

	public class Session
	{
	}
}

