using AcademicManagementSystem.Application.Abstraction.IRepository;
using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.RRModels.User;
using AcademicManagementSystem.Application.RRModels.UserEmployeeCompact;
using AcademicManagementSystem.Application.RRModels.UserStudentCompact;
using AcademicManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static AcademicManagementSystem.Domain.Enums;

namespace AcademicManagementSystem.Application.Services
{
    public class AuthService(IAuthRepository authRepository, IUserRepository userRepository, IEmployeeRepository employeeRepository) : IAuthService
    {
        private static int _userNameCounter = 1;


        #region Register User As Employee


        public async Task<int> RegisterEmployee(UserEmployeeCompactRequest model)
        {
            // Generate Unique Id
            Guid Id = Guid.NewGuid();



            // Generate Unique UserName
            var index = model.Email.IndexOf("@");
            string basename = model.Email.Substring(0, index);
            string userName = basename + _userNameCounter.ToString();
            int returnVal = await userRepository.CheckUserNameExists(userName);
            while (returnVal > 0)
            {
                _userNameCounter++;
                userName = basename + _userNameCounter.ToString();
                returnVal = await userRepository.CheckUserNameExists(userName);

            }



            //Generate Employee Code
            string LastempCode = await employeeRepository.GetLastEmpCode();
            string LastNumberStr = LastempCode.Substring(3);
            int num = Convert.ToInt32(LastNumberStr);
            int newNum = num + 1;
            string empCode = "EMP" + Convert.ToString(newNum);
            int count = await userRepository.CheckEmpCodeExists(empCode);
            while (count > 0)
            {
                newNum++;
                empCode = "EMP" + Convert.ToString(newNum);
                count = await userRepository.CheckEmpCodeExists(empCode);

            }




            // Create Employee  Object
            Employee employee = new Employee();
            employee.Id = Id;
            employee.Name = model.Name;
            employee.EmpCode = empCode;
            employee.Salary = model.Salary;
            employee.Gender = model.Gender;
            employee.Position = model.Position;



            // Create User Object
            UserRequest user = new UserRequest();
            user.Id = Id;
            user.UserName = userName;
            user.Email = model.Email;
            user.ContactNo = model.ContactNo;
            user.UserRole = UserRole.Employee;
            user.UserStatus = UserStatus.Pending;
            user.Password = model.Password;
            user.ConfirmPassword = model.ConfirmPassword;

            //Send user and employee to repository
            int returnCode = await authRepository.RegisterEmployee(employee, user);
            return returnCode;



        }

        #endregion



        #region Register User As Student


        public async Task<int> RegisterStudent(UserStudentCompactRequest model)
        {
            // Generate Unique Id
            Guid Id = Guid.NewGuid();



            // Generate Unique UserName
            var index = model.Email.IndexOf("@");
            string basename = model.Email.Substring(0, index);
            string userName = basename + _userNameCounter.ToString();
            int returnVal = await userRepository.CheckUserNameExists(userName);
            while (returnVal > 0)
            {
                _userNameCounter++;
                userName = basename + _userNameCounter.ToString();
                returnVal = await userRepository.CheckUserNameExists(userName);

            }







            // Create Student  Object
            Student student = new Student();
            student.Id = Id;
            student.Name = model.Name;
            student.Gender = model.Gender;
            student.DepartmentId = model.DepartmentId;
            student.Marks = model.Marks;



            // Create User Object
            UserRequest user = new UserRequest();
            user.Id = Id;
            user.UserName = userName;
            user.Email = model.Email;
            user.ContactNo = model.ContactNo;
            user.UserRole = UserRole.Student;
            user.UserStatus = UserStatus.Active;
            user.Password = model.Password;
            user.ConfirmPassword = model.ConfirmPassword;

            //Send user and student to repository
            int returnCode = await authRepository.RegisterStudent(student, user);
            return returnCode;



        }

        #endregion


    }
}
