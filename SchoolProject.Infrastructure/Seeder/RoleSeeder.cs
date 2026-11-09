using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrastructure.Seeder
{
  public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<Role> roleManager)
        {
            var rolesCount = await roleManager.Roles.CountAsync();
            if (rolesCount <= 0)
            {
                await roleManager.CreateAsync(new Role { Name = "Manger" });
                await roleManager.CreateAsync(new Role { Name = "Instructor" });
                await roleManager.CreateAsync(new Role { Name = "Student" });
            }
        }
    }
}
