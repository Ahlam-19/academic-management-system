using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.RRModels.UserStudentCompact
{
    public class UserStudentCompactRequest
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Guid DepartmentId { get; set; }
        public int Marks { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
