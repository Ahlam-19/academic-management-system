using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService courseService) : ControllerBase
    {


        //Add Course
        [HttpPost("")]
        public async Task<IActionResult> AddCourse(CourseRequest model)
        {
            int returnValue = await courseService.AddCourse(model);
            return returnValue > 0 ? Ok("Course Added Succesfully") : BadRequest("Failed to Add Course");
        }


        //Update Course
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCourse(Guid id, UpdateCourseRequest model)
        {
            int returnValue = await courseService.UpdateCourse(id, model);
            return returnValue > 0 ? Ok("Course Updated Succesfully") : BadRequest("Failed to Update Course");
        }


        //Delete Course
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            int returnValue = await courseService.DeleteCourse(id);
            return returnValue > 0 ? Ok("Course Deleted Succesfully") : BadRequest("Failed to Delete Course");
        }


        //Read All Course
        [HttpGet("")]
        public async Task<IActionResult> GetCourses(Guid id)
        {
            var list = await courseService.GetCourses();
            return list != null ? Ok(list) : NotFound("No Courses Found");
        }

        //Read Course By Id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ReadCourseById(Guid id)
        {
            var course = await courseService.GetCourseById(id);
            return course != null ? Ok(course) : NotFound("Course not Found");
        }
    }
}
