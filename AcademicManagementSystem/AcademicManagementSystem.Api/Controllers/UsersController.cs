using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.UserEmployeeCompact;
using AcademicManagementSystem.Application.RRModels.UserStudentCompact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {


        //Read  Employee User Compact By Id
        [HttpGet("user-employee-compact/{id:Guid}")]
        public async Task<IActionResult> GetEmployeeUserCompactById(Guid id)
        {
            var user = await userService.GetEmployeeUserCompactById(id);
            return user != null ? Ok(user) : NotFound("User Not Found");

        }

        //Read Basic Employee User Compact List
        [HttpGet("user-employee-basic-list")]
        public async Task<IActionResult> GetBasicEmployeeUserCompactList()
        {
            var list = await userService.GetBasicEmployeeUserCompactList();
            return list != null ? Ok(list) : NotFound(" No Users  Found");

        }

        //Update User  Employee Compact
        [HttpPut("employee/{id:Guid}")]
        public async Task<IActionResult> UpdateUserEmployeeCompact(UpdateUserEmployeeRequest model, Guid id)
        {
            int returnValue = await userService.UpdateUserEmployeeCompact(model, id);
            return returnValue > 1 ? Ok("User and Employee Updated Succesfully") : BadRequest("Failed to update ");

        }






        //Delete User
        [HttpDelete("{id:Guid}/{userRole:int}")]
        public async Task<IActionResult> DeleteUser(Guid id, UserRole userRole)
        {
            int returnValue = await userService.DeleteUser(id, userRole);
            return returnValue > 1 ? Ok("User  and Employee Deleted Succesfully") : BadRequest("Failed to delete ");

        }

        // Read All  Users-Only
        [HttpGet("")]
        public async Task<IActionResult> GetUsers()
        {
            var list = await userService.GetUsers();
            return list != null ? Ok(list) : NotFound("No Users Found");

        }

        //Read Only User By Id
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await userService.GetUserById(id);
            return user != null ? Ok(user) : NotFound("User Not Found");

        }






        //Read  Student User Compact By Id
        [HttpGet("user-student-compact/{id:Guid}")]
        public async Task<IActionResult> GetstudentUserCompactById(Guid id)
        {
            var user = await userService.GetStudentUserCompactById(id);
            return user != null ? Ok(user) : NotFound("User Not Found");

        }

        //Read Basic Student User Compact List
        [HttpGet("user-student-basic-list")]
        public async Task<IActionResult> GetBasicStudentUserCompactList()
        {
            var list = await userService.GetBasicStudentUserCompactList();
            return list != null ? Ok(list) : NotFound(" No Users  Found");

        }

        //Update User  Student Compact
        [HttpPut("student/{id:Guid}")]
        public async Task<IActionResult> UpdateUserStudentCompact(UpdateUserStudentRequest model, Guid id)
        {
            int returnValue = await userService.UpdateUserStudentCompact(model, id);
            return returnValue > 1 ? Ok("User and Student Updated Succesfully") : BadRequest("Failed to update ");

        }







    }
}
