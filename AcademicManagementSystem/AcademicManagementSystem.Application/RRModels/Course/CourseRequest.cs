using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Course
{
    public class CourseRequest
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public Guid DeptId { get; set; }
        public Decimal Fees { get; set; }
        public int Duration_Years { get; set; }


    }
}
