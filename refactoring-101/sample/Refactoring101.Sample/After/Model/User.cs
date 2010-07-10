namespace Refactoring101.Sample.After
{
	public class User
	{
		public string Name { get; set; }
		public string Location { get; set; }

		public User(string name, string location)
		{
			Name = name;
			Location = location;
		}

		public User()
		{
		}
	}
}