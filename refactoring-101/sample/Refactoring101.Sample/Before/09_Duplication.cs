using System.Data;
using System.Data.SqlClient;

namespace Refactoring101.Sample.Before
{
	public class EmployeeDataProvider
	{
		public IDataRecord GetEmployee(int employeeId)
		{
			using (var connection = new SqlConnection("some connection string"))
			{
				connection.Open();

				using (var cmd = new SqlCommand("dbo.cs_Employee_Get", connection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
					return cmd.ExecuteReader();
				}
			}
		}

		public IDataRecord GetEmployee(string username)
		{
			using (var connection = new SqlConnection("some connection string"))
			{
				connection.Open();

				using (var cmd = new SqlCommand("dbo.cs_Employee_GetByUsername", connection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@Username", SqlDbType.Int).Value = username;
					return cmd.ExecuteReader();
				}
			}
		}
	}
}
