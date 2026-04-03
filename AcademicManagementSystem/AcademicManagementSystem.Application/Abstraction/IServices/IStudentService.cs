using AcademicManagementSystem.Application.RRModels.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IServices
{
    public interface IStudentService
    {

        Task<StudentFullResponse> GetStudentById(Guid Id);

        Task<IEnumerable<StudentBasicResponse>> GetStudents();






        //Task<int> AddStudent(StudentRequest model);

        //Task<int> UpdateStudent(UpdateStudentRequest model, Guid Id);

        //Task<int> DeleteStudent(Guid Id);

    }
}
