using AutoMapper;

namespace SchoolProject.Core.Mappping.RoleMappng
{
  public partial class RoleProfile:Profile
    {
        public RoleProfile()
        {
            GetRoleListMapping();
            GetRoleByIdMapping();
        }

      
    }
}
