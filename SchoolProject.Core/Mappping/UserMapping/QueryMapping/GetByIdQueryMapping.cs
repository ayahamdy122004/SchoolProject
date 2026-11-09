using AutoMapper;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mappping.UserMapping
{
    public partial class UserProfile 
    {
        public void GetByIdQueryMapping()
        {
            
            CreateMap<User, GetByIdUserResponse>();
          
        }
    }
}
