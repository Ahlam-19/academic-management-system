using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Domain
{
    public class Enums
    {
        public enum Gender
        {
            Male = 1,
            Female = 2,
        }



        public enum UserRole
        {
            Admin = 1,
            SuperAdmin = 2,
            Student = 3,
            Employee = 4
        }



        public enum UserStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3,
            Active = 4,
            InActive = 5,
            Blocked = 6
        }
    }
}
