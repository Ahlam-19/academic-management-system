using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.UserStudentCompact
{
    public class UserStudentCompactBasicResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Marks { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
    }
}
