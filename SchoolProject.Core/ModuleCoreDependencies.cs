using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.AbsrractServices;
using SchoolProject.Service.Implementation;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //services.AddTransient<IStudentService,StudentService>();
           services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleCoreDependencies).Assembly));
            // autoMapper
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ModuleCoreDependencies).Assembly));
            return services;
        }   
    }
}
