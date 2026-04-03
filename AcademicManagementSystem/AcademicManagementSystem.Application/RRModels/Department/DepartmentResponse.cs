using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Department
{
    public class DepartmentResponse
    {
        public Guid Id { get; set; }
        public string DeptName { get; set; }
        public string Hod { get; set; }
        public string Location { get; set; }
    }
}
