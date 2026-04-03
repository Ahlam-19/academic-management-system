using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Department
{
    public class DepartmentRequest
    {
        public string Name { get; set; }
        public Guid HodId { get; set; }
        public string Location { get; set; }
    }
}
