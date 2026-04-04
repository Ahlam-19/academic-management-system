using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Services
{
    public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
    {
        #region Add Subject
        public async Task<int> AddSubject(SubjectRequest model)
        {
            int returnValue = await subjectRepository.AddSubject(model);
            return returnValue;
        }
        #endregion


        #region Delete Subject
        public async Task<int> DeleteSubject(Guid id)
        {
            int returnValue = await subjectRepository.DeleteSubject(id);
            return returnValue;
        }

        #endregion


        #region Read By Id
        public async Task<SubjectFullResponse> GetSubjectById(Guid id)
        {
            var sbj = await subjectRepository.GetSubjectById(id);
            return sbj;
        }

        #endregion


        #region Read All
        public async Task<IEnumerable<SubjectBasicResponse>> GetSubjects()
        {
            var list = await subjectRepository.GetSubjects();
            return list;
        }
        #endregion

        #region Update Subject
        public async Task<int> UpdateSubject(UpdateSubjectRequest model, Guid id)
        {
            int returnValue = await subjectRepository.UpdateSubject(model, id);
            return returnValue;
        }

        #endregion
    }
}
