using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Course
{

    public class CourseFullResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string DeptName { get; set; }
        public Decimal Fees { get; set; }
        public int Duration_Years { get; set; }


    }
}
