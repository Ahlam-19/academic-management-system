using AcademicManagementSystem.Application.Abstraction.IServices;
using AcademicManagementSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Application
{
    public static  class AssemblyReferences
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ISubjectService, SubjectService>();
            return services;
        }
    }
}
