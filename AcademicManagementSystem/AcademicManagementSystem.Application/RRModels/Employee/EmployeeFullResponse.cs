using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.RRModels.Employee
{
    public class EmployeeFullResponse
    {
        public Guid Id { get; set; }

        public int Experience { get; set; }
        public string Name { get; set; }

        public string EmpCode { get; set; }

        public Gender Gender { get; set; }

        public string Position { get; set; }

        public decimal AnnualSalary { get; set; }
    }
}
