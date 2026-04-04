using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Department;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Services
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        #region Add Department

        public async Task<int> AddDepartment(DepartmentRequest model)
        {
            int returnValue = await departmentRepository.AddDepartment(model);
            return returnValue;
        }

        #endregion


        #region Update Department

        public async Task<int> UpdateDepartment(UpdateDepartmentRequest model, string deptName)
        {
            int returnValue = await departmentRepository.UpdateDepartment(model, deptName);
            return returnValue;
        }

        #endregion


        #region Delete Department

        public async Task<int> DeleteDepartment(Guid id)
        {

            int returnValue = await departmentRepository.DeleteDepartment(id);
            return returnValue;
        }

        #endregion


        #region Read Department ById

        public async Task<DepartmentResponse> GetDepartmentById(Guid id)
        {
            var dept = await departmentRepository.GetDepartmentById(id);
            return dept;
        }

        #endregion


        #region Read All Departments

        public async Task<List<DepartmentResponse>> GetAllDepartments()
        {
            var list = await departmentRepository.GetAllDepartments();
            return list;
        }

        #endregion
    }
}
