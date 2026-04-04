using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Semester;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController(ISemesterService semesterService) : ControllerBase
    {


        //Add Semester
        [HttpPost("")]
        public async Task<IActionResult> AddSemester(SemesterRequest model)
        {
            int returnValue = await semesterService.AddSemester(model);
            return returnValue > 0 ? Ok("Semester Added Succesfully") : BadRequest("Failed To Add Semester");
        }


        //Delete Semester
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(Guid id)
        {
            int returnValue = await semesterService.DeleteSemester(id);
            return returnValue > 0 ? Ok("Semester Deleted Succesfully") : BadRequest("Failed To Delete Semester");
        }

        //Update Semester
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSemester(UpdateSemesterRequest model, Guid id)
        {
            int returnValue = await semesterService.UpdateSemester(model, id);
            return returnValue > 0 ? Ok("Semester Updated Succesfully") : BadRequest("Failed To Update Semester");
        }


        //Read All Semesters
        [HttpGet("")]
        public async Task<IActionResult> GetSemesters()
        {
            var list = await semesterService.GetSemesters();
            return list != null ? Ok(list) : NotFound("No Semesters Found");
        }


        //Read  Semester By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSemesterById(Guid id)
        {
            var semester = await semesterService.GetSemesterById(id);
            return semester != null ? Ok(semester) : NotFound("No Semester Found");
        }
    }
}
