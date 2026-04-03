using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public Guid DeptId { get; set; }
        public Decimal Fees { get; set; }
        public int Duration_Years { get; set; }

    }
}
