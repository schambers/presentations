namespace Refactoring101.Sample.After
{
	public class PayRoll
	{
		public void PayEmployee(Employee employee)
		{
			double weeklySalary = GetWeeklySalary(employee);

			CalculateEmployeeBenefits(employee, weeklySalary);

			// other stuff to actually print check
		}

		private double GetWeeklySalary(Employee employee)
		{
			double weeklySalary = employee.YearlySalary/52;
			weeklySalary -= weeklySalary * 0.065;

			return weeklySalary;
		}

		private void CalculateEmployeeBenefits(Employee employee, double weeklySalary)
		{
			foreach (Benefit benefit in  employee.Benefits)
				weeklySalary -= benefit.Amount;
		}
	}
}
