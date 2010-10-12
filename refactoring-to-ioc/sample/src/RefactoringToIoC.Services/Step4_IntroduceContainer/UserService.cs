using System;
using Ninject;
using Ninject.Modules;
using RefactoringToIoC.Services.Model;

namespace RefactoringToIoC.Services.Step4_IntroduceContainer
{
	// In this step, we've eliminated the poor man's DI,
	// and removed the default ctor so that we can inject instances
	// using an IoC container

	// AppStartup simulates the bootstrapping of configuration
	// of an IoC container in an MVC application

	public class AppStartup
	{
		public void AppStart()
		{
			IKernel kernel = new StandardKernel(new ServicesModule());

			// In an MVC app, we would register a controller factory that would inject
			// instances for us

			// MVCControllerFactory = new NinjectControllerFactory(kernel);
		}

		public void IncomingHttpRequest()
		{
			//var controller = ControllerFactory.GetController();
		}
	}

	public class ServicesModule : NinjectModule
	{
		public override void Load()
		{
			Bind<UserController>().ToSelf();
			Bind<IUserService>().To<UserService>();
			Bind<IAuthenticationService>().To<AuthenticationService>();
			Bind<IUserRepository>().To<UserRepository>();
		}
	}

	public class UserController
	{
		public UserController(IUserService userService)
		{
			UserService = userService;
		}

		public IUserService UserService { get; set; }
	}

	// Services from before, minus the default ctor on UserService
	// and added an IUserService

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

	public class UserService : IUserService
	{
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

	public interface IUserService
	{
		void CreateUser(string username, string password, string firstName, string lastName);
	}
}
