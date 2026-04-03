using AcademicManagementSystem.Application.RRModels.Department;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IRepository
{
    public interface IDepartmentRepository
    {
        Task<int> AddDepartment(DepartmentRequest model);

        Task<int> UpdateDepartment(UpdateDepartmentRequest model, string deptName);

        Task<int> DeleteDepartment(Guid id);

        Task<DepartmentResponse> GetDepartmentById(Guid id);

        Task<List<DepartmentResponse>> GetAllDepartments();
    }
}
