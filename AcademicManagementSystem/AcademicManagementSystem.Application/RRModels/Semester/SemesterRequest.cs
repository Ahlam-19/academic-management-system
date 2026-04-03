using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Semester
{
    public class SemesterRequest
    {
        public string SemesterName { get; set; }
        public Guid CourseId { get; set; }
    }
}
