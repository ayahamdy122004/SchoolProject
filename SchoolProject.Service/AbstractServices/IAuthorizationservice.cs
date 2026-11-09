using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.AbstractServices
{
    public interface IAuthorizationservice
    {
        public Task<string> AddRole(string roleName);
        public Task<bool> isNameRoleExist(string roleName);
        public Task<Role> GetRoleById(string roleId);
        public Task<string> EditRole(EditRoleRequest editRoleRequest);
        public Task<string> DeleteRole(string roleId);

        public Task<List<Role>> GetRoleList();
        public Task<ManageUserRolesResult> ManageUserRolesData(User user);

    }
}
