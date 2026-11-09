using SchoolProject.Core.Features.Authorization.Queries.Results;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mappping.RoleMappng
{
    public partial class RoleProfile
    {
        public void GetRoleListMapping()
        {
            CreateMap<Role, GetRoleListResponse>();
                
        }
    }
}
