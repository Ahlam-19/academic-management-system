using AcademicManagementSystem.Application.Abstraction.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {


        //////////////////Read All//////////////////////

        [HttpGet("")]
        public async Task<IActionResult> GetEmployees()
        {
            var employeelist = await employeeService.GetEmployees();
            return employeelist != null ? Ok(employeelist) : NotFound("No Employees found");


        }





        //////////////////ReadById//////////////////////

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await employeeService.GetEmployeeById(id);
            return employee != null ? Ok(employee) : NotFound("No Employee found");

        }














    }

}
