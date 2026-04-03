using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Course
{
    public class CourseBasicResponse
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string DeptName { get; set; }


    }
}
