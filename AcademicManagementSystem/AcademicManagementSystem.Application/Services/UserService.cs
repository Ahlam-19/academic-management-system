using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.User;
using AcademicManagementSystem.Application.RRModels.UserEmployeeCompact;
using AcademicManagementSystem.Application.RRModels.UserStudentCompact;
using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {


        #region Employee User Compact



        #region  Read  Employee User Compact By Id

        public async Task<UserEmployeeCompactFullResponse> GetEmployeeUserCompactById(Guid id)
        {
            var user = await userRepository.GetEmployeeUserCompactById(id);
            return user;
        }

        #endregion


        #region Read Basic Employee User Compact List
        public async Task<IEnumerable<UserEmployeeCompactBasicResponse>> GetBasicEmployeeUserCompactList()
        {
            var list = await userRepository.GetBasicEmployeeUserCompactList();
            return list;
        }
        #endregion


        #region Update User  Employee Compact

        public async Task<int> UpdateUserEmployeeCompact(UpdateUserEmployeeRequest model, Guid id)
        {
            int returnValue = await userRepository.UpdateUserEmployeeCompact(model, id);
            return returnValue;
        }

        #endregion



        #endregion


        #region Student User Compact

        #region Read Student User Compact By Id
        public async Task<UserStudentCompactFullResponse> GetStudentUserCompactById(Guid id)
        {
            var std = await userRepository.GetStudentUserCompactById(id);
            return std;
        }

        #endregion


        #region  Read Basic Student User Compact List
        public async Task<IEnumerable<UserStudentCompactBasicResponse>> GetBasicStudentUserCompactList()
        {
            var list = await userRepository.GetBasicStudentUserCompactList();
            return list;
        }

        #endregion


        #region Update Student User Compact
        public async Task<int> UpdateUserStudentCompact(UpdateUserStudentRequest model, Guid id)
        {
            int returnValue = await userRepository.UpdateUserStudentCompact(model, id);
            return returnValue;
        }

        #endregion

        #endregion




        #region Delete  User

        public async Task<int> DeleteUser(Guid id, UserRole userRole)
        {
            int returnValue = await userRepository.DeleteUser(id, userRole);
            return returnValue;
        }

        #endregion

        # region Read All  Users-Only

        public async Task<IEnumerable<UserBasicResponse>> GetUsers()
        {
            var list = await userRepository.GetUsers();
            return list;
        }

        #endregion

        #region Read Only User By Id

        public async Task<UserFullResponse> GetUserById(Guid id)
        {
            var user = await userRepository.GetUserById(id);
            return user;
        }

        #endregion






    }
}
