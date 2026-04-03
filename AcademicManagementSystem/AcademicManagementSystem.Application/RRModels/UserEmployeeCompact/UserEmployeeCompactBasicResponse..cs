using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.RRModels.UserEmployeeCompact
{
    public class UserEmployeeCompactBasicResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string EmpCode { get; set; }
        public Gender Gender { get; set; }

        public decimal Salary { get; set; }

        public string Email { get; set; }
        public string ContactNo { get; set; }


    }
}
