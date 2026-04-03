using AcademicManagementSystem.Application.RRModels.User;
using AcademicManagementSystem.Application.RRModels.UserEmployeeCompact;
using AcademicManagementSystem.Application.RRModels.UserStudentCompact;
using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.Abstraction.IServices
{
    public interface IUserService
    {
        //Task<int> AddUser(UserRequest model);




        Task<IEnumerable<UserEmployeeCompactBasicResponse>> GetBasicEmployeeUserCompactList();
        Task<UserEmployeeCompactFullResponse> GetEmployeeUserCompactById(Guid id);
        Task<int> UpdateUserEmployeeCompact(UpdateUserEmployeeRequest model, Guid id);



        Task<IEnumerable<UserStudentCompactBasicResponse>> GetBasicStudentUserCompactList();
        Task<UserStudentCompactFullResponse> GetStudentUserCompactById(Guid id);
        Task<int> UpdateUserStudentCompact(UpdateUserStudentRequest model, Guid id);


        Task<int> DeleteUser(Guid id, UserRole userRole);
        Task<IEnumerable<UserBasicResponse>> GetUsers();
        Task<UserFullResponse> GetUserById(Guid id);




    }
}
