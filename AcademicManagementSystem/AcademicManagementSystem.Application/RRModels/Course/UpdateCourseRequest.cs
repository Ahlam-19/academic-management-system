using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Course
{
    public class UpdateCourseRequest
    {
        public Decimal Fees { get; set; }
        public Guid DeptId { get; set; }
        public int Duration_Years { get; set; }


    }
}
