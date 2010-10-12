using System;
using RefactoringToIoC.Services.Model;

namespace RefactoringToIoC.Services.Step2_CreateSeams
{
	//
	// DANGER WILL ROBINSON!!
	//
	// ONLY use this as an intermediate step. Do not leave your code
	// in this state. This is simply a bootstrapping method
	//

	public interface IAuthenticationService
	{
		bool IsPasswordValid(User user);
	}

	public class AuthenticationServiceProxy : IAuthenticationService
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

	public class UserRepositoryProxy : IUserRepository
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
		public UserService() : this(new UserRepositoryProxy(), new AuthenticationServiceProxy())
		{
		}

		public UserService(IUserRepository userRepository, IAuthenticationService authenticationService)
		{
			UserRepository = userRepository;
			AuthenticationService = authenticationService;
		}

		public IUserRepository UserRepository { get; set; }
		public IAuthenticationService AuthenticationService { get; set; }

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
