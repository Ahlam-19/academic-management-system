using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController(ISubjectService subjectService) : ControllerBase
    {
        //Add subject
        [HttpPost("")]

        public async Task<IActionResult> AddSubject(SubjectRequest model)
        {
            int returnValue = await subjectService.AddSubject(model);
            return returnValue > 0 ? Ok("Subject Added Succesfully") : BadRequest("Failed to Add Subject");
        }


        //Delete Subject
        [HttpDelete("{id:Guid}")]

        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            int returnValue = await subjectService.DeleteSubject(id);
            return returnValue > 0 ? Ok("Subject Deleted Succesfully") : BadRequest("Failed to Delete Subject");
        }



        //Update Subject
        [HttpPut("{id:Guid}")]

        public async Task<IActionResult> UpdateSubject(UpdateSubjectRequest model, Guid id)
        {
            int returnValue = await subjectService.UpdateSubject(model, id);
            return returnValue > 0 ? Ok("Subject Updated Succesfully") : BadRequest("Failed to Update Subject");
        }


        //Read  Subject By Id
        [HttpGet("{id:Guid}")]

        public async Task<IActionResult> GetSubjectById(Guid id)
        {
            var subject = await subjectService.GetSubjectById(id);
            return subject != null ? Ok(subject) : NotFound("Subject Not Found");

        }

        //Read All Subjects
        [HttpGet("")]
        public async Task<IActionResult> GetSubjects()
        {
            var list = await subjectService.GetSubjects();
            return list != null ? Ok(list) : NotFound("No Subjects Found");

        }



    }
}
