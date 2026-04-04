using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.RRModels.Course;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AcademicManagementSystem.Persistence.Repository
{

    public class CourseRepository : ICourseRepository
    {
        private string connectionString = "";
        public CourseRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");
        }

        #region Add Course
        public async Task<int> AddCourse(CourseRequest model)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "SpInsertCourses";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@courseName", SqlDbType.NVarChar, 100).Value = model.CourseName;
            cmd.Parameters.Add("@courseCode", SqlDbType.NVarChar, 20).Value = model.CourseCode;
            cmd.Parameters.Add("@deptId", SqlDbType.UniqueIdentifier).Value = model.DeptId;
            cmd.Parameters.Add("@fees", SqlDbType.Decimal).Value = model.Fees;
            cmd.Parameters.Add("@years", SqlDbType.Int).Value = model.Duration_Years;
            con.Open();

            int returnvalue = await cmd.ExecuteNonQueryAsync();
            return returnvalue;


        }

        #endregion



        #region Update Course
        public async Task<int> UpdateCourse(Guid id, UpdateCourseRequest model)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spUpdateCourse";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            cmd.Parameters.Add("@deptId", SqlDbType.UniqueIdentifier).Value = model.DeptId;
            cmd.Parameters.Add("@fees", SqlDbType.Decimal).Value = model.Fees;
            cmd.Parameters.Add("@years", SqlDbType.Int).Value = model.Duration_Years;
            con.Open();

            int returnvalue = await cmd.ExecuteNonQueryAsync();
            return returnvalue;

        }
        #endregion



        #region Delete Course
        public async Task<int> DeleteCourse(Guid id)
        {

            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spDeleteCourse";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();

            int returnvalue = await cmd.ExecuteNonQueryAsync();
            return returnvalue;

        }
        #endregion


        #region Read Course By Id
        public async Task<CourseFullResponse> GetCourseById(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadCourseById";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            CourseFullResponse course = new CourseFullResponse();

            if (rdr.Read())
            {
                course.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                course.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"]);
                course.CourseName = Convert.ToString(rdr["CourseName"]);
                course.CourseCode = Convert.ToString(rdr["CourseCode"]);
                course.DeptName = Convert.ToString(rdr["DeptName"]);
                course.Fees = Convert.ToDecimal(rdr["Fees"]);
                course.Duration_Years = Convert.ToInt32(rdr["Duration_Years"]);

            }

            return course;
        }


        #endregion



        #region Read All Courses
        public async Task<IEnumerable<CourseBasicResponse>> GetCourses()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadCourses";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<CourseBasicResponse> courses = new List<CourseBasicResponse>();
            while (rdr.Read())
            {
                CourseBasicResponse course = new CourseBasicResponse();
                course.Id = Guid.Parse(Convert.ToString(rdr["Id"]));
                course.CourseName = Convert.ToString(rdr["CourseName"]);
                course.CourseCode = Convert.ToString(rdr["CourseCode"]);
                course.DeptName = Convert.ToString(rdr["DeptName"]);

                courses.Add(course);
            }

            return courses;
        }
    }
          ;

    #endregion


}
