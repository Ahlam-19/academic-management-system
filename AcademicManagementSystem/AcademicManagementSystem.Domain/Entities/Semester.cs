using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Domain.Entities
{
    public class Semester : BaseEntity
    {
        public string SemesterName { get; set; }
        public Guid CourseId { get; set; }
    }
}
