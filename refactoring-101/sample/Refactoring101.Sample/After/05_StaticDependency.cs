namespace Refactoring101.Sample.After
{
	public class RegistrationService
	{
		private IRegistrationProcessor RegistrationProcessor { get; set; }

		public RegistrationService(IRegistrationProcessor registrationProcessor)
		{
			RegistrationProcessor = registrationProcessor;
		}

		public void CreateRegistration(Person person)
		{
			Course course = RegistrationProcessor.Create(person);

			// more processing of Registration here
		}
	}

	public class RegistrationProcessor : IRegistrationProcessor
	{
		public Course Create(Person person)
		{
			return StaticRegistrationProcessor.Create(person);
		}
	}

	public interface IRegistrationProcessor
	{
		Course Create(Person person);
	}

	public static class StaticRegistrationProcessor
	{
		public static Course Create(Person person)
		{
			// some work here to create course

			return new Course();
		}
	}

	public class Course
	{
	}
}
