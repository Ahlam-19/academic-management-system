using AcademicManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IRepository
{
    public interface IEmployeeRepository
    {
        Task<string> GetLastEmpCode();
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(Guid id);





        //Task<int> AddEmployee(Employee model);

    }
}
