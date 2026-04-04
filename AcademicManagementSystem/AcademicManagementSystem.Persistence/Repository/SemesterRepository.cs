using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.RRModels.Semester;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AcademicManagementSystem.Persistence.Repository
{
    public class SemesterRepository : ISemesterRepository
    {

        private string connectionString = "";

        public SemesterRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");
        }
        #region Add Semester
        public async Task<int> AddSemester(SemesterRequest model)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spInsertSemester";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = model.SemesterName;
            cmd.Parameters.Add("@courseId", SqlDbType.UniqueIdentifier).Value = model.CourseId;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }

        #endregion


        #region Delete Semester
        public async Task<int> DeleteSemester(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spDeleteSemester";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }
        #endregion


        #region Read Semesters
        public async Task<IEnumerable<SemesterResponse>> GetSemesters()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadSemesters";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<SemesterResponse> list = new List<SemesterResponse>();
            while (rdr.Read())
            {
                SemesterResponse semester = new SemesterResponse();
                semester.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                semester.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                semester.SemesterName = Convert.ToString(rdr["Semestername"]);
                semester.CourseCode = Convert.ToString(rdr["Course"]);

                list.Add(semester);
            }

            return list;
        }
        #endregion



        #region Read Semester By Id
        public async Task<SemesterResponse> GetSemesterById(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadSemesterById";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            SemesterResponse semester = new SemesterResponse();

            if (rdr.Read())
            {
                semester.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                semester.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                semester.SemesterName = Convert.ToString(rdr["Semestername"]);
                semester.CourseCode = Convert.ToString(rdr["Course"]);

            }

            return semester;
        }
        #endregion

        #region Update Semester
        public async Task<int> UpdateSemester(UpdateSemesterRequest model, Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spUpdateSemester";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = model.SemesterName;
            cmd.Parameters.Add("@courseId", SqlDbType.UniqueIdentifier).Value = model.CourseId;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }
        #endregion
    }
}
