using System.Data;
using System.Data.SqlClient;

namespace Refactoring101.Sample.After
{
	public class EmployeeDataProvider
	{
		private SqlConnection OpenSqlConnection()
		{
			var sqlConnection = new SqlConnection("some connection string");
			sqlConnection.Open();

			return sqlConnection;
		}

		private SqlCommand GetSprocCommand(string sprocName, SqlConnection connection)
		{
			var sqlCommand = new SqlCommand(string.Format("dbo.{0}", sprocName)) { CommandType = CommandType.StoredProcedure };
			return sqlCommand;
		}

		public IDataRecord GetEmployee(int employeeId)
		{
			using (var connection = OpenSqlConnection()) // Refactored repetitive SqlConnection code and connection.Open()
			using (var cmd = GetSprocCommand("dbo.cs_Employee_Get", connection))
			{
				cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
				return cmd.ExecuteReader();
			}
		}

		public IDataRecord GetEmployee(string username)
		{
			using (var connection = OpenSqlConnection()) // Refactored repetitive SqlConnection code and connection.Open()
			using (var cmd = GetSprocCommand("cs_Employee_Get", connection))
			{
				cmd.Parameters.Add("@Username", SqlDbType.Int).Value = username;
				return cmd.ExecuteReader();
			}
		}
	}
}
