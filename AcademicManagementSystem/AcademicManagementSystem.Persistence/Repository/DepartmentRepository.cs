using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.RRModels.Department;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AcademicManagementSystem.Persistence.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private string connectionString = "";

        public DepartmentRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("WebApiConnection");

        }


        #region Add Department

        public async Task<int> AddDepartment(DepartmentRequest model)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spInsertDepartment";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@hodId", SqlDbType.UniqueIdentifier).Value = model.HodId;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = model.Name;
            cmd.Parameters.Add("@location", SqlDbType.NVarChar, 100).Value = model.Location;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }

        #endregion


        #region Update Department

        public async Task<int> UpdateDepartment(UpdateDepartmentRequest model, string deptName)
        {

            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spUpdateDepartment";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@hodId", SqlDbType.UniqueIdentifier).Value = model.HodId;
            cmd.Parameters.Add("@deptName", SqlDbType.NVarChar, 50).Value = deptName;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }

        #endregion


        #region Delete Department

        public async Task<int> DeleteDepartment(Guid id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spDeleteDepartment";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            int returnValue = await cmd.ExecuteNonQueryAsync();
            return returnValue;
        }


        #endregion


        #region Read Department ById

        public async Task<DepartmentResponse> GetDepartmentById(Guid id)
        {

            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadDepartmentById";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            DepartmentResponse dpt = new DepartmentResponse();

            if (rdr.Read())
            {
                dpt.Id = Guid.Parse(Convert.ToString(rdr["DeptId"]));
                dpt.DeptName = Convert.ToString(rdr["DeptName"]);
                dpt.Location = Convert.ToString(rdr["Location"]);
                dpt.Hod = Convert.ToString(rdr["Hod"]);


            }

            return dpt;
        }

        #endregion


        #region Read All Departments

        public async Task<List<DepartmentResponse>> GetAllDepartments()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "spReadDepartments";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();
            List<DepartmentResponse> dptList = new List<DepartmentResponse>();
            while (rdr.Read())
            {
                DepartmentResponse dpt = new DepartmentResponse();
                dpt.Id = Guid.Parse(Convert.ToString(rdr["DeptId"]));
                dpt.DeptName = Convert.ToString(rdr["DeptName"]);
                dpt.Location = Convert.ToString(rdr["Location"]);
                dpt.Hod = Convert.ToString(rdr["Hod"]);

                dptList.Add(dpt);

            }
            return dptList;
        }

        #endregion
    }
}
