namespace Refactoring101.Sample.After
{
	public class UserResult
	{
		public bool HasError { get; set;}
		public string ErrorMessage { get; set; }
		public User User { get; set; }
	}
}