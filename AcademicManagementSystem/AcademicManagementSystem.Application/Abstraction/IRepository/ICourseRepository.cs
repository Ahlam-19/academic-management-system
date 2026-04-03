using AcademicManagementSystem.Application.RRModels.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IRepository
{
    public interface ICourseRepository
    {
        Task<int> AddCourse(CourseRequest model);

        Task<int> UpdateCourse(Guid id, UpdateCourseRequest model);

        Task<int> DeleteCourse(Guid id);

        Task<CourseFullResponse> GetCourseById(Guid id);

        Task<IEnumerable<CourseBasicResponse>> GetCourses();
    }
}
