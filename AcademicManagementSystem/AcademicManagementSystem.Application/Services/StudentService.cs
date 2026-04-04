using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Services
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {


        #region ReadById
        public async Task<StudentFullResponse> GetStudentById(Guid Id)
        {
            var student = await studentRepository.GetStudentById(Id);
            return student;
        }

        #endregion

        #region ReadAll
        public async Task<IEnumerable<StudentBasicResponse>> GetStudents()
        {
            var list = await studentRepository.GetStudents();
            return list;
        }
        #endregion




        
    }
}
