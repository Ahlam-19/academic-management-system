using AcademicManagementSystem.Application;
using AcademicManagementSystem.Persistence;


namespace AcademicManagementSystem.Api
{
    public static class AssemblyReferences
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
       
            services.AddOpenApi();
            services.AddApplicationServices();
            services.AddPersistenceServices();
            return services;
        }
    
    }
}
