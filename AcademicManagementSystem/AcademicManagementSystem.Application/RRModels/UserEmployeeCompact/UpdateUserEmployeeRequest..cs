using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.UserEmployeeCompact
{

    public class UpdateUserEmployeeRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public decimal Salary { get; set; }

    }
}
