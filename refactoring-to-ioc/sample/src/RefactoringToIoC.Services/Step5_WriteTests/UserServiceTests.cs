using System;
using Moq;
using NUnit.Framework;
using RefactoringToIoC.Services.Model;
using RefactoringToIoC.Services.Step4_IntroduceContainer;

namespace RefactoringToIoC.Services.Step5_WriteTests
{
	[TestFixture]
	public class UserServiceTests
	{
		private Mock<IUserRepository> _userRepositoryMock;
		private Mock<IAuthenticationService> _authenticationServiceMock;
		private UserService _userService;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_userRepositoryMock = new Mock<IUserRepository>();
			_authenticationServiceMock = new Mock<IAuthenticationService>();

			_userService = new UserService(_userRepositoryMock.Object, _authenticationServiceMock.Object);
		}

		[Test]
		public void can_save_user()
		{
			_authenticationServiceMock.Setup(x => x.IsPasswordValid(It.IsAny<User>())).Returns(true);

			_userService.CreateUser("user", "pass", "Test", "User");

			_userRepositoryMock.Verify(x => x.Save(It.IsAny<User>()));
		}

		[Test]
		[ExpectedException(typeof(Exception))]
		public void throws_exception_if_password_is_not_valid()
		{
			_authenticationServiceMock.Setup(x => x.IsPasswordValid(It.IsAny<User>())).Returns(false);

			_userService.CreateUser("user", "12", "Test", "User");
		}
	}
}
