using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Semester
{
    public class SemesterResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string SemesterName { get; set; }
        public string CourseCode { get; set; }
    }
}
