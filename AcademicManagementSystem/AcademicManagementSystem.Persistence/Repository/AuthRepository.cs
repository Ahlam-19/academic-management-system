using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.RRModels.User;
using AcademicManagementSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AcademicManagementSystem.Persistence.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private string connectionString = "";
        public AuthRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");
        }


        #region Register User As Employee


        public async Task<int> RegisterEmployee(Employee emp, UserRequest user)
        {


            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spInsertUserAsEmployee";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //adding employee parameters
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = user.Id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = emp.Name;
            cmd.Parameters.Add("@empCode", SqlDbType.NVarChar, 30).Value = emp.EmpCode;
            cmd.Parameters.Add("@position", SqlDbType.NVarChar, 30).Value = emp.Position;
            cmd.Parameters.Add("@gender", SqlDbType.Int).Value = emp.Gender;
            cmd.Parameters.Add("@salary", SqlDbType.Decimal).Value = emp.Salary;


            //adding user parameters
            cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 50).Value = user.UserName;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = user.Email;
            cmd.Parameters.Add("@contactNo", SqlDbType.NVarChar, 100).Value = user.ContactNo;
            cmd.Parameters.Add("@userRole", SqlDbType.Int).Value = user.UserRole;
            cmd.Parameters.Add("@userStatus", SqlDbType.Int).Value = user.UserStatus;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = user.Password;
            cmd.Parameters.Add("@confirmPassword", SqlDbType.NVarChar, 50).Value = user.ConfirmPassword;



            con.Open();

            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }

        #endregion

        #region Register User As Student


        public async Task<int> RegisterStudent(Student student, UserRequest user)
        {


            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spInsertUserAsStudent";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //adding student parameters
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = student.Id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = student.Name;
            cmd.Parameters.Add("@gender", SqlDbType.Int).Value = student.Gender;
            cmd.Parameters.Add("@deptId", SqlDbType.UniqueIdentifier).Value = student.DepartmentId;
            cmd.Parameters.Add("@marks", SqlDbType.Int).Value = student.Marks;


            //adding user parameters
            cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 50).Value = user.UserName;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = user.Email;
            cmd.Parameters.Add("@contactNo", SqlDbType.NVarChar, 100).Value = user.ContactNo;
            cmd.Parameters.Add("@userRole", SqlDbType.Int).Value = user.UserRole;
            cmd.Parameters.Add("@userStatus", SqlDbType.Int).Value = user.UserStatus;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = user.Password;
            cmd.Parameters.Add("@confirmPassword", SqlDbType.NVarChar, 50).Value = user.ConfirmPassword;



            con.Open();

            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }

        #endregion

    }
}
