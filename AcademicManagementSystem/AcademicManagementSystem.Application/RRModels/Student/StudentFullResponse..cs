using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.RRModels.Student
{
    public class StudentFullResponse
    {

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Marks { get; set; }

        public string DeptName { get; set; }
    }
}
