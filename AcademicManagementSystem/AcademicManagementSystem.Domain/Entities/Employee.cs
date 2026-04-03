using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public string EmpCode { get; set; }

        public Gender Gender { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }
    }
}
