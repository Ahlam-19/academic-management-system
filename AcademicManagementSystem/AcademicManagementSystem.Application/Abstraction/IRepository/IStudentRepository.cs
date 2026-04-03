using AcademicManagementSystem.Application.RRModels.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IRepository
{
    public interface IStudentRepository
    {


        Task<IEnumerable<StudentBasicResponse>> GetStudents();

        Task<StudentFullResponse> GetStudentById(Guid Id);





        //Task<int> Addstudent(Student model);


        //Task<int> UpdateStudent(UpdateStudentRequest model, Guid Id);

        //Task<int> DeleteStudent(Guid Id);


    }
}
