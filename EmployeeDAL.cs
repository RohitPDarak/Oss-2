using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using BOL;


namespace DAL
{
	public class EmployeeDAL
	{
		public static string conenctionString = @"server=localhost;user=root;database=knowitdb;password=123456789";
		public static List<Employee> GetAll()
		{
			List<Employee> employees = new List<Employee>();
			IDbConnection conn = new MySqlConnection(conenctionString);
			try
			{
				conn.Open();
				string query = "SELECT * From emp";
				IDbCommand cmd = new MySqlCommand(query, conn as MySqlConnection);
				cmd.CommandType = CommandType.Text;   // 
				IDataReader reader = cmd.ExecuteReader();  //ResultSet
				while (reader.Read())
				{
					Employee emp = new Employee();
					emp.ID = int.Parse(reader["EMPNO"].ToString()); 
					emp.Designation = reader["JOB"].ToString();
					emp.Salary = double.Parse(reader["SAL"].ToString());
					employees.Add(emp);
				}
				reader.Close();
			}
			catch (MySqlException excpetion)
			{
				string error = excpetion.Message;
			}
			finally
			{
				conn.Close();
			}
			return employees;
		}
		
	}
}