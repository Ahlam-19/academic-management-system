using AcademicManagementSystem.Application.RRModels.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IServices
{
    public interface ISubjectService
    {
        Task<int> AddSubject(SubjectRequest model);
        Task<int> DeleteSubject(Guid id);
        Task<int> UpdateSubject(UpdateSubjectRequest model, Guid id);
        Task<IEnumerable<SubjectBasicResponse>> GetSubjects();
        Task<SubjectFullResponse> GetSubjectById(Guid id);
    }
}
