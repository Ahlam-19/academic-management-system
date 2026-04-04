using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.RRModels.Student;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Persistence.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private string connectionString = "";

        public StudentRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");
        }

        #region ReadById
        public async Task<StudentFullResponse> GetStudentById(Guid Id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadStudentById";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = Id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            StudentFullResponse std = new StudentFullResponse();
            if (rdr.Read())
            {
                std.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                std.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                std.Name = Convert.ToString(rdr["Name"]);
                std.Gender = Enum.Parse<Gender>(Convert.ToString(rdr["Gender"]));
                std.Marks = Convert.ToInt32(rdr["Marks"]);
                std.DeptName = Convert.ToString(rdr["DeptName"]);


            }
            return std;
        }

        #endregion

        #region ReadAll
        public async Task<IEnumerable<StudentBasicResponse>> GetStudents()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadStudents";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<StudentBasicResponse> stdList = new List<StudentBasicResponse>();
            while (rdr.Read())
            {
                StudentBasicResponse std = new StudentBasicResponse();
                std.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                std.Name = Convert.ToString(rdr["Name"]);
                std.Marks = Convert.ToInt32(rdr["Marks"]);
                std.DeptName = Convert.ToString(rdr["DeptName"]);

                stdList.Add(std);

            }
            return stdList;
        }
        #endregion





    }


}
