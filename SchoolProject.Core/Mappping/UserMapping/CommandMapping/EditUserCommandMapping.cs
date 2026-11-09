using AutoMapper;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
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
        public void EditUserCommandMapping()
        {
            CreateMap<EditUserCommand, User>();

        }


    }
}

