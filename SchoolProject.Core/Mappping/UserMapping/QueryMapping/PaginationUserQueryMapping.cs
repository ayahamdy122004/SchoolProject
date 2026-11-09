using AutoMapper;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;

namespace SchoolProject.Core.Mappping.UserMapping
{
    public partial class UserProfile 
    {
 
        public void PaginationUserQueryMpping()
        {
            CreateMap<User, GetPaginationUserResponse>();
        }
    }
}
