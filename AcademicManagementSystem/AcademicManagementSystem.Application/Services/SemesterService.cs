using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Semester;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Services
{
    public class SemesterService(ISemesterRepository semesterRepository) : ISemesterService
    {
        #region Add Semester
        public async Task<int> AddSemester(SemesterRequest model)
        {
            int returnValue = await semesterRepository.AddSemester(model);
            return returnValue;
        }

        #endregion


        #region Delete Semester
        public async Task<int> DeleteSemester(Guid id)
        {
            int returnValue = await semesterRepository.DeleteSemester(id);
            return returnValue;
        }
        #endregion


        #region Read Semesters
        public async Task<IEnumerable<SemesterResponse>> GetSemesters()
        {
            var list = await semesterRepository.GetSemesters();
            return list;
        }


        #endregion


        #region Read Semester By Id

        public async Task<SemesterResponse> GetSemesterById(Guid id)
        {
            var semester = await semesterRepository.GetSemesterById(id);
            return semester;
        }
        #endregion


        #region Update Semester
        public async Task<int> UpdateSemester(UpdateSemesterRequest model, Guid id)
        {
            int returnValue = await semesterRepository.UpdateSemester(model, id);
            return returnValue;
        }


        #endregion
    }
}
