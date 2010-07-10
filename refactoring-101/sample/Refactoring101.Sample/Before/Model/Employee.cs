using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring101.Sample.Before
{
	public class Employee
	{
		public double YearlySalary { get; private set; }
		public IEnumerable<Benefit> Benefits { get; private set; }
	}
}
