using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public Guid SemesterId { get; set; }
    }
}
