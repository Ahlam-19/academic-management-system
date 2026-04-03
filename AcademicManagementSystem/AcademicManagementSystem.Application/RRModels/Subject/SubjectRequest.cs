using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Subject
{
    public class SubjectRequest
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public Guid SemesterId { get; set; }
    }
}
