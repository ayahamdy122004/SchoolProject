using AutoMapper;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entities.Identity;
namespace SchoolProject.Core.Mappping.UserMapping
{
    public partial class UserProfile 
    {
        public void AddUserCommandMapping()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}
