using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController(IDepartmentService departmentService) : ControllerBase
    {
        //Add Department
        [HttpPost("")]
        public async Task<IActionResult> AddDepartment(DepartmentRequest model)
        {
            int returnValue = await departmentService.AddDepartment(model);
            return returnValue > 0 ? Ok(" Department Added succesfully") : BadRequest("Failed to add department");
        }


        //Read All Departments
        [HttpGet("")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var list = await departmentService.GetAllDepartments();
            return list != null ? Ok(list) : NotFound("No Departments Found");
        }


        //Read Department By Id
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var dept = await departmentService.GetDepartmentById(id);
            return dept != null ? Ok(dept) : NotFound("No Department Found");

        }

        //Delete Department
        [HttpDelete("{id:Guid}")]

        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            int returnValue = await departmentService.DeleteDepartment(id);
            return returnValue > 0 ? Ok(" Department Deleted succesfully") : BadRequest("Failed to delete department");
        }


        //Update Department
        [HttpPut("{deptName}")]

        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentRequest model, string deptName)
        {
            int returnValue = await departmentService.UpdateDepartment(model, deptName);
            return returnValue > 0 ? Ok(" Department  HOD Updated succesfully") : BadRequest("Failed to Update Department Hod");
        }

    }
}
