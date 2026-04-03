using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Employee
{
    public class EmployeeBasicResponse
    {

        public Guid Id { get; set; }

        public int Experience { get; set; }
        public string Name { get; set; }
        public decimal AnnualSalary { get; set; }

    }
}
