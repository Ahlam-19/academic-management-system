using AcademicManagementSystem.Application.RRModels.User;
using AcademicManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application.Abstraction.IRepository
{
    public interface IAuthRepository
    {
        Task<int> RegisterEmployee(Employee emp, UserRequest user);

        Task<int> RegisterStudent(Student student, UserRequest user);

    }
}
