using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.RRModels.User;
using AcademicManagementSystem.Application.RRModels.UserEmployeeCompact;
using AcademicManagementSystem.Application.RRModels.UserStudentCompact;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private string connectionString = "";
        public UserRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");
        }


        #region Check UserName Exists
        public async Task<int> CheckUserNameExists(string username)

        {


            using SqlConnection con = new SqlConnection(connectionString);
            string query = $@"Select dbo. CheckUserNameExists (@username)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
            con.Open();
            object result = await cmd.ExecuteScalarAsync();
            int count = Convert.ToInt32(result);
            return count;
        }

        #endregion

        #region Check Email Exists

        public async Task<int> CheckEmailExists(string email)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = $@"Select dbo. CheckUserExistsByEmail (@email)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;
            con.Open();
            object result = await cmd.ExecuteScalarAsync();
            int count = Convert.ToInt32(result);
            return count;

        }
        #endregion





        #region Employee User Compact


        #region Check EmpCode Exists

        public async Task<int> CheckEmpCodeExists(string empCode)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = $@"Select dbo. CheckEmpCodeExists (@empCode)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@empCode", SqlDbType.NVarChar, 30).Value = empCode;
            con.Open();
            object result = await cmd.ExecuteScalarAsync();
            int count = Convert.ToInt32(result);
            return count;

        }
        #endregion



        #region Read  Employee User Compact By Id


        public async Task<UserEmployeeCompactFullResponse> GetEmployeeUserCompactById(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadUserEmployeeCompact";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            UserEmployeeCompactFullResponse userCompact = new UserEmployeeCompactFullResponse();
            if (rdr.Read())
            {
                userCompact.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                userCompact.UserName = Convert.ToString(rdr["UserName"]);
                userCompact.Email = Convert.ToString(rdr["Email"]);
                userCompact.ContactNo = Convert.ToString(rdr["ContactNo"]);
                userCompact.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                userCompact.UserRole = Enum.Parse<UserRole>(Convert.ToString(rdr["UserRole"]));
                userCompact.UserStatus = Enum.Parse<UserStatus>(Convert.ToString(rdr["UserStatus"]));
                userCompact.Attempts = Convert.ToInt32(rdr["Attempts"]);
                userCompact.Password = Convert.ToString(rdr["Password"]);
                userCompact.EmpCode = Convert.ToString(rdr["EmpCode"]);
                userCompact.Name = Convert.ToString(rdr["Name"]);
                userCompact.Position = Convert.ToString(rdr["Position"]);
                userCompact.Salary = Convert.ToDecimal(rdr["Salary"]);
                userCompact.Gender = Enum.Parse<Gender>(Convert.ToString(rdr["Gender"]));


            }

            return userCompact;
        }

        #endregion




        #region Read Basic Employee User Compact List



        public async Task<IEnumerable<UserEmployeeCompactBasicResponse>> GetBasicEmployeeUserCompactList()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadUserEmployeeBasicCompact";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<UserEmployeeCompactBasicResponse> list = new List<UserEmployeeCompactBasicResponse>();
            while (rdr.Read())
            {
                UserEmployeeCompactBasicResponse userBasicCompact = new UserEmployeeCompactBasicResponse();

                userBasicCompact.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                userBasicCompact.Email = Convert.ToString(rdr["Email"]);
                userBasicCompact.ContactNo = Convert.ToString(rdr["ContactNo"]);
                userBasicCompact.EmpCode = Convert.ToString(rdr["EmpCode"]);
                userBasicCompact.Name = Convert.ToString(rdr["Name"]);
                userBasicCompact.Salary = Convert.ToDecimal(rdr["Salary"]);
                userBasicCompact.Gender = Enum.Parse<Gender>(Convert.ToString(rdr["Gender"]));

                list.Add(userBasicCompact);


            }

            return list;
        }

        #endregion



        #region Update Employee User Compact

        public async Task<int> UpdateUserEmployeeCompact(UpdateUserEmployeeRequest model, Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spUpdateUserEmployeeCompact";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = model.Name;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = model.Email;
            cmd.Parameters.Add("@contactNo", SqlDbType.NVarChar, 100).Value = model.ContactNo;
            cmd.Parameters.Add("@salary", SqlDbType.Decimal).Value = model.Salary;

            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;

        }






        #endregion




        #endregion



        #region Student User Compact


        #region Read Student User Compact By Id
        public async Task<UserStudentCompactFullResponse> GetStudentUserCompactById(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadUserStudentCompact";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            UserStudentCompactFullResponse userCompact = new UserStudentCompactFullResponse();
            if (rdr.Read())
            {
                userCompact.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                userCompact.UserName = Convert.ToString(rdr["UserName"]);
                userCompact.Email = Convert.ToString(rdr["Email"]);
                userCompact.ContactNo = Convert.ToString(rdr["ContactNo"]);
                userCompact.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                userCompact.UserRole = Enum.Parse<UserRole>(Convert.ToString(rdr["UserRole"]));
                userCompact.UserStatus = Enum.Parse<UserStatus>(Convert.ToString(rdr["UserStatus"]));
                userCompact.Attempts = Convert.ToInt32(rdr["Attempts"]);
                userCompact.Password = Convert.ToString(rdr["Password"]);
                userCompact.Name = Convert.ToString(rdr["Name"]);
                userCompact.Gender = Enum.Parse<Gender>(Convert.ToString(rdr["Gender"]));
                userCompact.Marks = Convert.ToInt32(rdr["Marks"]);


            }

            return userCompact;
        }

        #endregion


        #region  Read Basic Student User Compact List
        public async Task<IEnumerable<UserStudentCompactBasicResponse>> GetBasicStudentUserCompactList()
        {

            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadUserStudentBasicCompact";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<UserStudentCompactBasicResponse> list = new List<UserStudentCompactBasicResponse>();
            while (rdr.Read())
            {
                UserStudentCompactBasicResponse userCompact = new UserStudentCompactBasicResponse();
                userCompact.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                userCompact.Email = Convert.ToString(rdr["Email"]);
                userCompact.ContactNo = Convert.ToString(rdr["ContactNo"]);
                userCompact.Name = Convert.ToString(rdr["Name"]);
                userCompact.Marks = Convert.ToInt32(rdr["Marks"]);

                list.Add(userCompact);

            }

            return list;
        }

        #endregion


        #region Update Student User Compact
        public async Task<int> UpdateUserStudentCompact(UpdateUserStudentRequest model, Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spUpdateUserStudentCompact";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = model.Name;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = model.Email;
            cmd.Parameters.Add("@contactNo", SqlDbType.NVarChar, 100).Value = model.ContactNo;
            cmd.Parameters.Add("@deptId", SqlDbType.UniqueIdentifier).Value = model.DeptId;

            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;


        }

        #endregion


        #endregion





        #region Delete User

        public async Task<int> DeleteUser(Guid id, UserRole userRole)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spDeleteUser";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            cmd.Parameters.AddWithValue("@userRole", userRole);
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;

        }

        #endregion





        #region Read All  Users-Only
        public async Task<IEnumerable<UserBasicResponse>> GetUsers()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadUsers";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<UserBasicResponse> list = new List<UserBasicResponse>();
            while (rdr.Read())
            {
                UserBasicResponse user = new UserBasicResponse();
                user.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                user.UserName = Convert.ToString(rdr["UserName"]);
                user.Email = Convert.ToString(rdr["Email"]);
                user.ContactNo = Convert.ToString(rdr["ContactNo"]);

                list.Add(user);
            }

            return list;
        }

        #endregion

        #region Read Only Users By Id

        public async Task<UserFullResponse> GetUserById(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadUserById";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            UserFullResponse user = new UserFullResponse();

            if (rdr.Read())
            {
                user.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                user.UserName = Convert.ToString(rdr["UserName"]);
                user.Email = Convert.ToString(rdr["Email"]);
                user.ContactNo = Convert.ToString(rdr["ContactNo"]);
                user.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                user.UserRole = Enum.Parse<UserRole>(Convert.ToString(rdr["UserRole"]));
                user.UserStatus = Enum.Parse<UserStatus>(Convert.ToString(rdr["UserStatus"]));
                user.Attempts = Convert.ToInt32(rdr["Attempts"]);
                user.Password = Convert.ToString(rdr["Password"]);
                user.ConfirmPassword = Convert.ToString(rdr["ConfirmPassword"]);
                user.Salt = Convert.ToString(rdr["Salt"]);


            }

            return user;
        }



        #endregion





    }
}
