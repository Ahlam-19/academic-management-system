using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Domain.Entities
{
    public class Users : BaseEntity
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public UserRole UserRole { get; set; }
        public UserStatus UserStatus { get; set; }
        public int Attempts { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
    }
}
