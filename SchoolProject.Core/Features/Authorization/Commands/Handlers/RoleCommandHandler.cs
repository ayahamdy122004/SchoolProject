using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Service.AbstractServices;


namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
   public class RoleCommandHandler: ResponseHandler, IRequestHandler<AddRoleCommand, Response<string>>
                                                      , IRequestHandler<EditRoleCommand, Response<string>>
    {
        #region fields
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAuthorizationservice service;
        #endregion
        #region ctor
        public RoleCommandHandler(RoleManager<IdentityRole> roleManager, IAuthorizationservice service)
        {
            this.roleManager = roleManager;
            this.service = service;
        }
        #endregion
        #region handles functions
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await service.AddRole(request.RoleName);
            if (result == "Success") return Success("");
            return BadRequest<string>();
        

    }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await service.EditRole(request);
            if (result == "notFound") return NotFound<string>();
            else if (result == "Success") return Success("Updated Successfully");
            else
                return BadRequest<string>(result);
        }
        #endregion
    }
}
