using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.UserStudentCompact
{
    public class UpdateUserStudentRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public Guid DeptId { get; set; }

    }
}
