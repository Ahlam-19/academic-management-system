using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Employee;
using AcademicManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {



        #region ReadAll

        public async Task<IEnumerable<EmployeeBasicResponse>> GetEmployees()
        {
            IEnumerable<Employee> empList = await employeeRepository.GetEmployees();
            List<EmployeeBasicResponse> empBasicList = new List<EmployeeBasicResponse>();
            foreach (Employee emp in empList)
            {
                EmployeeBasicResponse empBasic = new EmployeeBasicResponse();
                empBasic.Id = emp.Id;
                empBasic.Name = emp.Name;
                empBasic.AnnualSalary = emp.Salary * 12;

                empBasicList.Add(empBasic);
            }
            return empBasicList;
        }
        #endregion



        #region ReadById

        public async Task<EmployeeFullResponse> GetEmployeeById(Guid id)
        {
            Employee employee = await employeeRepository.GetEmployeeById(id);
            EmployeeFullResponse emp = new EmployeeFullResponse();
            emp.Id = employee.Id;
            emp.EmpCode = employee.EmpCode;
            emp.Name = employee.Name;
            emp.Position = employee.Position;
            emp.AnnualSalary = employee.Salary * 12;
            emp.Gender = employee.Gender;

            return emp;
        }
        #endregion


    }
}
