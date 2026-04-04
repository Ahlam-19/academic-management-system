using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Services
{
    public class CourseService(ICourseRepository courseRepository) : ICourseService
    {

        #region Add Course
        public async Task<int> AddCourse(CourseRequest model)
        {
            int returnvalue = await courseRepository.AddCourse(model);
            return returnvalue;
        }

        #endregion



        #region Update Course
        public async Task<int> UpdateCourse(Guid id, UpdateCourseRequest model)
        {
            int returnvalue = await courseRepository.UpdateCourse(id, model);
            return returnvalue;
        }
        #endregion



        #region Delete Course
        public async Task<int> DeleteCourse(Guid id)
        {

            int returnvalue = await courseRepository.DeleteCourse(id);
            return returnvalue;

        }
        #endregion


        #region Read Course By Id
        public async Task<CourseFullResponse> GetCourseById(Guid id)
        {
            var course = await courseRepository.GetCourseById(id);
            return course;

        }
        #endregion



        #region Read All Courses
        public async Task<IEnumerable<CourseBasicResponse>> GetCourses()
        {
            var courses = await courseRepository.GetCourses();
            return courses;
        }
        #endregion



    }
}
