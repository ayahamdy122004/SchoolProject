using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.AbstractServices;
using SchoolProject.Service.Implementation;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
       
            services.AddScoped<IAUthenticationService, AUthenticationService>();
            services.AddScoped<SchoolProject.Service.AbstractServices.IAuthorizationservice,
                SchoolProject.Service.Implementation.AuthorizationService>();
            return services;
        }
    }
}
