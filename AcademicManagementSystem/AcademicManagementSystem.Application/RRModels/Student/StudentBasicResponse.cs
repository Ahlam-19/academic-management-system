using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.RRModels.Student
{
    public class StudentBasicResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public string DeptName { get; set; }


    }
}
