using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Subject
{
    public class SubjectBasicResponse
    {
        public Guid Id { get; set; }

        public string SubjectName { get; set; }
        public string Semester { get; set; }
    }
}
