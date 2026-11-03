using CRUDusingADO.Models;
using System.Data.SqlClient;

namespace CRUDusingADO
{
    public class EmployeeDataAccessLayer
    {
        public string cs = ConnectionString.GetConnectionString();

        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection sc = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spEmployeesGetAll", sc);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sc.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    employees.Add(employee);
                }
                return employees;
            }
        }
        public List<Employee> getEmployeeByID(int ID)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from Employees where EmployeeID=@EmployeeID", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@EmployeeID", ID);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) {
                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    employees.Add(employee);
                }
                return employees;
            }
        }
    }
}
