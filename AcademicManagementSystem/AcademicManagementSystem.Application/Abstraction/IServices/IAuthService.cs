using AcademicManagementSystem.Application.RRModels.UserEmployeeCompact;
using AcademicManagementSystem.Application.RRModels.UserStudentCompact;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IServices
{
    public interface IAuthService
    {
        Task<int> RegisterEmployee(UserEmployeeCompactRequest model);

        Task<int> RegisterStudent(UserStudentCompactRequest model);

    }
}
