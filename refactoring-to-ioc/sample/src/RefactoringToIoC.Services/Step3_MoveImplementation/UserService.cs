using System;
using RefactoringToIoC.Services.Model;

namespace RefactoringToIoC.Services.Step3_MoveImplementation
{
	//
	// DANGER WILL ROBINSON!!
	//
	// ONLY use this as an intermediate step. Do not leave your code
	// in this state. This is simply a bootstrapping method
	//

	// In this step, we've moved the implementations
	// out of the static classes and into the concrete classes
	// that used to be the proxy classes

	public interface IAuthenticationService
	{
		bool IsPasswordValid(User user);
	}

	public class AuthenticationService : IAuthenticationService
	{
		public bool IsPasswordValid(User user)
		{
			return user.Password.Length > 5;
		}
	}

	public interface IUserRepository
	{
		bool IsUserAvailable(string username);
		void Save(User user);
	}

	public class UserRepository : IUserRepository
	{
		public bool IsUserAvailable(string username)
		{
			throw new NotImplementedException();
		}

		public void Save(User user)
		{
			throw new NotImplementedException();
		}
	}

	public class UserService
	{
		public UserService() : this(new UserRepository(), new AuthenticationService())
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
}
