using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace volksoft.Models
{
    public class Employee
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Employee> GetEmployees()
        {
            string sQuery = "select * from Employees";
            List<Employee> _Employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sQuery, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        employee.Name = reader.GetString(reader.GetOrdinal("Name"));
                        employee.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                        employee.Email = reader.GetString(reader.GetOrdinal("Email"));
                        employee.Address = reader.GetString(reader.GetOrdinal("Address"));
                        _Employees.Add(employee);
                    }
                }
            }
            //Session["Employees"] = _Employees;
            return _Employees;
        }
        public void SaveEmployee(Employee employee)
        {
            string sQuery = string.Empty;
            if (employee.Id > 0)
            {
                sQuery = $@"update Employees set Name='{employee.Name}',PhoneNumber='{employee.PhoneNumber}',Email='{employee.Email}'
                          ,Address='{employee.Address}' where Id = {employee.Id};";
            }
            else
            {
                sQuery = @"Insert into Employees(Name,PhoneNumber,Email,Address) 
                  Values(@Name, @PhoneNumber, @Email, @Address)";

            }
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Employee> DeleteEmployee(int id)
        {
            string sQuery = "delete from Employees where Id=" + id;
            List<Employee> _Employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return _Employees;
        }
    }
    public class SalaryModel
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal Salary { get; set; }
        public decimal LOP { get; set; }
        public List<SalaryModel> GetSalaries()
        {
            string sQuery = "select * from SalaryModels";
            List<SalaryModel> _Salaries = new List<SalaryModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sQuery, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        SalaryModel employee = new SalaryModel();
                        employee.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        employee.EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        employee.Salary = reader.GetDecimal(reader.GetOrdinal("Salary"));
                        employee.SalaryDate = reader.GetDateTime(reader.GetOrdinal("SalaryDate"));
                        employee.LOP = reader.GetDecimal(reader.GetOrdinal("LOP"));
                        _Salaries.Add(employee);
                    }
                }
            }
            //Session["Employees"] = _Employees;
            return _Salaries;
        }
        public void SaveSalaries(SalaryModel salaryModel)
        {
            string sQuery = string.Empty;
            if (salaryModel.Id > 0)
            {
                sQuery = $@"update SalaryModels set Salary='{salaryModel.Salary}'
                          ,SalaryDate='{salaryModel.SalaryDate.ToString("MM-dd-yyyy")}',LOP='{salaryModel.LOP}' where Id = {salaryModel.Id};";
            }
            else
            {
                sQuery = @"Insert into SalaryModels(EmployeeId,Salary,SalaryDate,LOP) 
                  Values(@EmployeeId, @Salary, @SalaryDate, @LOP)";

            }
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", salaryModel.EmployeeId);
                    cmd.Parameters.AddWithValue("@Salary", salaryModel.Salary);
                    cmd.Parameters.AddWithValue("@SalaryDate", salaryModel.SalaryDate);
                    cmd.Parameters.AddWithValue("@LOP", salaryModel.LOP);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<SalaryModel> DeleteSalaries(int id)
        {
            string sQuery = "delete from SalaryModels where Id=" + id;
            List<SalaryModel> _Employees = new List<SalaryModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return _Employees;
        }
    }
}