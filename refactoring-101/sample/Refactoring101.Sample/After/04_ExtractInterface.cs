namespace Refactoring101.Sample.After
{
	// Dependency breaking technique

	public interface IPresenter
	{
		bool IsPresenter { get; set; }
		int NumberOfPresentations { get; set; }
		void GivePresentationToClass(Session session);
	}

	public class CodeCampAttendee : IPresenter
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
