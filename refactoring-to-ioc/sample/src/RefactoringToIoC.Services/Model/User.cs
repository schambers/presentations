using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringToIoC.Services.Model
{
	public class User
	{
		public User(string username, string password, string firstName, string lastName)
		{
			Username = username;
			Password = password;
			FirstName = firstName;
			LastName = lastName;
		}

		public string Username { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
