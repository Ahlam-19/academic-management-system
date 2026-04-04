using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.RRModels.Subject;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AcademicManagementSystem.Persistence.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private string connectionString = "";

        public SubjectRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");
        }

        #region Add Subject
        public async Task<int> AddSubject(SubjectRequest model)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spInsertSubject";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@subCode", SqlDbType.NVarChar, 30).Value = model.SubjectCode;
            cmd.Parameters.Add("@subName", SqlDbType.NVarChar, 50).Value = model.SubjectName;
            cmd.Parameters.Add("@semesterId", SqlDbType.UniqueIdentifier).Value = model.SemesterId;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;


        }
        #endregion


        #region Delete Subject
        public async Task<int> DeleteSubject(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spDeleteSubject";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }

        #endregion


        #region Read By Id
        public async Task<SubjectFullResponse> GetSubjectById(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadSubjectById";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            SubjectFullResponse sbj = new SubjectFullResponse();

            if (rdr.Read())
            {
                sbj.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                sbj.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                sbj.SubjectCode = Convert.ToString(rdr["SubjectCode"]);
                sbj.SubjectName = Convert.ToString(rdr["SubjectName"]);
                sbj.Semester = Convert.ToString(rdr["Semester"]);


            }
            return sbj;
        }

        #endregion


        #region Read All
        public async Task<IEnumerable<SubjectBasicResponse>> GetSubjects()
        {

            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadSubjects";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<SubjectBasicResponse> list = new List<SubjectBasicResponse>();
            while (rdr.Read())
            {

                SubjectBasicResponse sbj = new SubjectBasicResponse();

                sbj.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                sbj.SubjectName = Convert.ToString(rdr["SubjectName"]);
                sbj.Semester = Convert.ToString(rdr["Semester"]);

                list.Add(sbj);

            }
            return list;
        }
        #endregion

        #region Update Subject
        public async Task<int> UpdateSubject(UpdateSubjectRequest model, Guid id)
        {

            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spUpdateSubject";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@subCode", SqlDbType.NVarChar, 30).Value = model.SubjectCode;
            cmd.Parameters.Add("@semesterId", SqlDbType.UniqueIdentifier).Value = model.SemesterId;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }

        #endregion
    }
}
