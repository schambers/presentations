namespace Refactoring101.Sample.Before
{
	public class PayRoll
	{
		public void PayEmployee(Employee employee)
		{
			double weeklySalary = employee.YearlySalary/52;
			weeklySalary -= weeklySalary * 0.065;

			foreach (Benefit benefit in  employee.Benefits)
				weeklySalary -= benefit.Amount;

			// other stuff to actually print check
		}
	}
}
