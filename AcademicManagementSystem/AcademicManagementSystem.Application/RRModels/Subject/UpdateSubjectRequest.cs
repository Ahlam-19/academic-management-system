using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Subject
{
    public class UpdateSubjectRequest
    {
        public string SubjectCode { get; set; }

        public Guid SemesterId { get; set; }

    }
}
