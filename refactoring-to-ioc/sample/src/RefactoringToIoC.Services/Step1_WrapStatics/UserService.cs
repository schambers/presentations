using System;
using RefactoringToIoC.Services.Model;

namespace RefactoringToIoC.Services.Step1_WrapStatics
{
	public interface IAuthenticationService
	{
		bool IsPasswordValid(User user);
	}

	public class AuthenticationServiceProxy
	{
		public bool IsPasswordValid(User user)
		{
			return AuthenticationService.IsPasswordValid(user);
		}
	}

	public interface IUserRepository
	{
		bool IsUserAvailable(string username);
		void Save(User user);
	}

	public class UserRepositoryProxy
	{
		public bool IsUserAvailable(string username)
		{
			return UserRepository.IsUserAvailable(username);
		}

		public void Save(User user)
		{
			UserRepository.Save(user);
		}
	}

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
