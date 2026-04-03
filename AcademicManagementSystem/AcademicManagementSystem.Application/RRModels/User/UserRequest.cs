using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.RRModels.User
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        public UserRole UserRole { get; set; }
        public UserStatus UserStatus { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
