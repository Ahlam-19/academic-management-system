using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Subject
{
    public class SubjectFullResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string Semester { get; set; }
    }
}
