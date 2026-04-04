using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Persistence.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString = "";
        public EmployeeRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");
        }


        #region Get Last EmpCode
        public async Task<string> GetLastEmpCode()

        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = $@"Select dbo. GetLastEmpcode ()";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            object result = await cmd.ExecuteScalarAsync();
            string LastEmpCode = Convert.ToString(result);
            return LastEmpCode;
        }

        #endregion

        #region ReadAll
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = $@"SELECT * FROM Employees";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<Employee> employees = new List<Employee>();
            while (rdr.Read())
            {
                Employee emp = new Employee();
                emp.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                emp.EmpCode = Convert.ToString(rdr["EmpCode"]);
                emp.Name = Convert.ToString(rdr["Name"]);
                emp.Position = Convert.ToString(rdr["Position"]);
                emp.Salary = Convert.ToDecimal(rdr["Salary"]);
                emp.Gender = Enum.Parse<Gender>(Convert.ToString(rdr["Gender"]));

                employees.Add(emp);

            }
            return employees;

        }

        #endregion

        #region ReadByID
        public async Task<Employee> GetEmployeeById(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = $@" Select * From Employees Where Id = '{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            Employee emp = new Employee();
            if (rdr.Read())
            {
                emp.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                emp.EmpCode = Convert.ToString(rdr["EmpCode"]);
                emp.Name = Convert.ToString(rdr["Name"]);
                emp.Position = Convert.ToString(rdr["Position"]);
                emp.Salary = Convert.ToDecimal(rdr["Salary"]);
                emp.Gender = Enum.Parse<Gender>(Convert.ToString(rdr["Gender"]));

            }

            return emp;


        }

        #endregion






     
    }
}
