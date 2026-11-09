
using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Quaries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Results;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Request;
using SchoolProject.Service.AbstractServices;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class RoleHandlerQuery : ResponseHandler,
        IRequestHandler<GetRoleListQuery, Response<List<GetRoleListResponse>>>
        ,IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>> ,
        IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResult>> 
    {
        #region fields
        private readonly IAuthorizationservice service;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        #endregion

        #region constructors
        public RoleHandlerQuery(IAuthorizationservice service, IMapper mapper, UserManager<User> userManager)
        {
            this.service = service;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        #endregion

        #region handle function
        public async Task<List<GetRoleListResponse>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var result = await service.GetRoleList();
            var resMapper= mapper.Map<List<GetRoleListResponse>>(result);
            return resMapper;
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await service.GetRoleById(request.RoleId);
            if(result == null) return NotFound<GetRoleByIdResponse>("Role not found");   
            return Success<GetRoleByIdResponse>(mapper.Map<GetRoleByIdResponse>(result), "Role found");


        }

        public async Task<Response<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserRolesResult>("");
            var result = await service.ManageUserRolesData(user);
            return Success(result);
        }

        #endregion

    }
}
