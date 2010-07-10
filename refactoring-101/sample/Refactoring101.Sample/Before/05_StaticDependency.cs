namespace Refactoring101.Sample.Before
{
	public class RegistrationService
	{
		public void CreateRegistration(Person person)
		{
			Course course = RegistrationProcessor.Create(person);

			// more processing of Registration here
		}
	}

	public static class RegistrationProcessor
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
