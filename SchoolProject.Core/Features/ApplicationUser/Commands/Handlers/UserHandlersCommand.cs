using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserHandlersCommand : ResponseHandler, IRequestHandler<AddUserCommand, SchoolProject.Core.Bases.Response<string>>,
                                                         IRequestHandler<EditUserCommand, SchoolProject.Core.Bases.Response<string>>,
                                                          IRequestHandler<DeleteUserCommand, SchoolProject.Core.Bases.Response<string>>,
                                                          IRequestHandler<ChangeUserPasswordCommand, SchoolProject.Core.Bases.Response<string>>
    {
        #region fields
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        #endregion


        #region constructors
        public UserHandlersCommand(IMapper mapper , UserManager<User> userManager) :base()
        {
            this.mapper = mapper;
            this.userManager = userManager;    
        }
        #endregion


        #region handler functiond
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user1= await userManager.FindByEmailAsync(request.Email);   
            if(user1 != null)
            {
                return BadRequest<string>("User with this Nmae Or email already exists");   
            }
            var user2 = await userManager.FindByNameAsync(request.UserName);
            if (user2 != null) {
                return BadRequest<string>("User with this Nmae Or email already exists");

            }
            var user = mapper.Map<User>(request);
            var result = await userManager.CreateAsync(user, request.Password)  ;
            if (result.Succeeded)
            {
                return Created<string>("User created successfully", user.Id);
            }
            else
            {
                return BadRequest<string>("User creation failed");
            }   

        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user1 = await userManager.FindByEmailAsync(request.Email);
            if (user1 != null)
            {
                return BadRequest<string>("User with this Nmae Or email already exists");
            }
            var user2 = await userManager.FindByNameAsync(request.UserName);
            if (user2 != null)
            {
                return BadRequest<string>("User with this Nmae Or email already exists");

            }
            var user = mapper.Map<User>(request);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Created<string>("User updated successfully", user.Id);
            }
            else
            {
                return BadRequest<string>("User Edition failed");
            }


        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
          var user=await userManager.FindByIdAsync(request.Id.ToString());
          if (user is null)
          {
            return NotFound<string>("User not found");
            }

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Success<string>("User deleted successfully");
            }
            else
            {
                return BadRequest<string>("User deletion failed");
            }
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            //get user
            //check if user is exist
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (user == null) return NotFound<string>();

            //Change User Password
            var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            //var user1=await _userManager.HasPasswordAsync(user);
            //await _userManager.RemovePasswordAsync(user);
            //await _userManager.AddPasswordAsync(user, request.NewPassword);

            //result
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success<string>("Change Password is Done Successfully !!!!!!!!!");
        }
        #endregion

    }
}
