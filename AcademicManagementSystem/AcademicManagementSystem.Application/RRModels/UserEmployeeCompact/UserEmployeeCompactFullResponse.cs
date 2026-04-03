using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.RRModels.UserEmployeeCompact
{
    public class UserEmployeeCompactFullResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }
        public string EmpCode { get; set; }
        public Gender Gender { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public string Email { get; set; }
        public string ContactNo { get; set; }
        public UserRole UserRole { get; set; }
        public UserStatus UserStatus { get; set; }
        public int Attempts { get; set; }
        public string Password { get; set; }


    }
}
