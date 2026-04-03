using AcademicManagementSystem.Application.RRModels.Semester;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IRepository
{
    public interface ISemesterRepository
    {
        Task<IEnumerable<SemesterResponse>> GetSemesters();
        Task<SemesterResponse> GetSemesterById(Guid id);
        Task<int> AddSemester(SemesterRequest model);
        Task<int> UpdateSemester(UpdateSemesterRequest model, Guid id);
        Task<int> DeleteSemester(Guid id);


    }
}
