using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Request;
using SchoolProject.Service.AbstractServices;

namespace SchoolProject.Service.Implementation
{
    public class AuthorizationService : IAuthorizationservice
    {
        #region fields
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        #endregion

        #region constructor
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
           
            this.roleManager = roleManager;
        }
        #endregion

        #region handles functions   
        public async Task<string> AddRole(string roleName)
        {
           if(await isNameRoleExist(roleName))
            {
                return "Role already exists";
            }
            var result = await roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                return "Failed to create role";
            }
            return "Role created successfully"; 
        }

        public async Task<string> DeleteRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if(role == null)
                return "Role not found";
            var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);
            if (usersInRole.Any())
                return "Role cannot be deleted because it has users assigned";
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded) return "Role deleted successfully";
            var errors = string.Join("-", result.Errors);
            return errors;
        }

       

        public async Task<string> EditRole(EditRoleRequest request)
        {
            //check role is exist or not
            var role = await roleManager.FindByIdAsync(request.roleId.ToString());
            if (role == null)
                return "notFound";
            role.Name = request.RoleName;
            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;
        }

        public async Task<Role> GetRoleById(string roleId)
        {
           return await roleManager.FindByIdAsync(roleId);
        }

        public async Task<List<Role>> GetRoleList()
        {
           return await roleManager.Roles.Select(r => new Role
            {
                Id = int.Parse(r.Id),
                Name = r.Name,
                NormalizedName = r.NormalizedName,
                ConcurrencyStamp = r.ConcurrencyStamp
            }).ToListAsync();
        }

        public async Task<bool> isNameRoleExist(string roleName)
        {
            return await roleManager.RoleExistsAsync(roleName);
        }

        public async Task<ManageUserRolesResult> ManageUserRolesData(User user)
        {

            var response = new ManageUserRolesResult();
            var  RolesList=new List<UserRoles>();   
            response.UserId = user.Id;
            var allRoles = await roleManager.Roles.ToListAsync();
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in allRoles)
            {
             var userRole = new UserRoles
                {
                   
                    Name = role.Name,
                    HasRole = userRoles.Contains(role.Name)
                };
                RolesList.Add(userRole);
            }
            return response;
        }
        #endregion

    }

}
