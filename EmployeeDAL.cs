// using Comment
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
