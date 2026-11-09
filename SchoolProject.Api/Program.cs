
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.Core.MiddleWare;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.data;
using SchoolProject.Infrastructure.Seeder;
using SchoolProject.Service;

namespace SchoolProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            #region dependency injication
            //dbcontext 
            builder.Services.AddDbContext<SchoolProject.Infrastructure.data.AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            ///Repository
            builder.Services.AddInfrastructureDependencies(builder.Configuration);
            ///Service
           builder.Services.AddServiceDependencies(builder.Configuration);
            builder.Services.AddCoreDependencies();
            #endregion
            ////////////////
            // register jwt settings as singleton
            var jwtSettings = new JwtSettings();
            builder.Configuration.GetSection("jwtSettings").Bind(jwtSettings);
            builder.Services.AddSingleton(jwtSettings);

            // 2. تسجيل الـ Identity (هذا السطر هو الذي يحل مشكلة UserManager)
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            ///swagger  
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            //seder roles

            //using (var scope = app.Services.CreateScope())
            //{
            //    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            //    await RoleSeeder.SeedAsync(roleManager);
            //    await UserSeeder.SeedAsync(userManager);
            //}
            ////////////
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
