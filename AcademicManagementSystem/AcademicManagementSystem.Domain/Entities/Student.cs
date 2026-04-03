using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Guid DepartmentId { get; set; }
        public int Marks { get; set; }
    }
}
