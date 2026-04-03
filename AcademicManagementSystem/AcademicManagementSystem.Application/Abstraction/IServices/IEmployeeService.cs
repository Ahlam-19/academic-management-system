using AcademicManagementSystem.Application.RRModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeBasicResponse>> GetEmployees();
        Task<EmployeeFullResponse> GetEmployeeById(Guid id);





        //Task<int> AddEmployee(EmployeeRequest model);

    }
}
