using AcademicManagementSystem.Application.Abstraction.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService studentService) : ControllerBase
    {

        //////////////////ReadAll//////////////////////

        [HttpGet("")]
        public async Task<IActionResult> GetStudents()
        {
            var studentList = await studentService.GetStudents();
            return studentList != null ? Ok(studentList) : NotFound("No students found");
        }



        //////////////////ReadById//////////////////////

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetStudentById(Guid Id)
        {
            var student = await studentService.GetStudentById(Id);
            return student != null ? Ok(student) : NotFound("No student found");
        }






      

    }
}
