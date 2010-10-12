using System;
using RefactoringToIoC.Services.Model;

namespace RefactoringToIoC.Services.Before
{
	public class UserService
	{
		public void CreateUser(string username, string password, string firstName, string lastName)
		{
			var user = new User(username, password, firstName, lastName);

			if (UserRepository.IsUserAvailable(username))
				throw new Exception("Account unavailable");

			if (!AuthenticationService.IsPasswordValid(user))
				throw new Exception("Account password is not valid");

			UserRepository.Save(user);
		}
	}

	public static class UserRepository
	{
		public static bool IsUserAvailable(string username)
		{
			throw new NotImplementedException();
		}

		public static void Save(User user)
		{
			throw new NotImplementedException();
		}
	}

	public static class AuthenticationService
	{
		public static bool IsPasswordValid(User user)
		{
			return user.Password.Length > 5;
		}
	}
}
