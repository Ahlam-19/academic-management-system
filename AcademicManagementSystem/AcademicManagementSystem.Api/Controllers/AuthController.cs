using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.UserEmployeeCompact;
using AcademicManagementSystem.Application.RRModels.UserStudentCompact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, IUserRepository userRepository) : ControllerBase
    {

        //Register Employee User Compact
        [HttpPost("register-employee")]
        public async Task<IActionResult> RegisterEmployee(UserEmployeeCompactRequest model)
        {
            //Check If password and confirm-password are same
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Password and Confirm Password do not match");
            }

            else
            {
                //Check If user  with same email already Exists
                int count = await userRepository.CheckEmailExists(model.Email);
                if (count <= 0)
                {
                    //Register User
                    int returnValue = await authService.RegisterEmployee(model);
                    return returnValue > 1 ? Ok("User Registered as Employee Successfully") : BadRequest("Registration Failed");
                }

                else
                {
                    return BadRequest("User with same email already exists");
                }
            }



        }



        //Register Student User Compact
        [HttpPost("register-student")]
        public async Task<IActionResult> RegisterStudent(UserStudentCompactRequest model)
        {
            //Check If password and confirm-password are same
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Password and Confirm Password do not match");
            }

            else
            {
                //Check If user  with same email already Exists
                int count = await userRepository.CheckEmailExists(model.Email);
                if (count <= 0)
                {
                    //Register User
                    int returnValue = await authService.RegisterStudent(model);
                    return returnValue > 1 ? Ok("User Registered as Student Successfully") : BadRequest("Registration Failed");
                }

                else
                {
                    return BadRequest("User with same email already exists");
                }
            }



        }
    }
}
