using System.Collections.Generic;

namespace Refactoring101.Sample.After
{
	public class Employee
	{
		public double YearlySalary { get; private set; }
		public IEnumerable<Benefit> Benefits { get; private set; }
	}
}
