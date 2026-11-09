using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Handlers
{
  public  class UserHandlersQuery:ResponseHandler,IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetPaginationUserResponse>>,
                                                  IRequestHandler<GetUserByIdQuery, SchoolProject.Core.Bases.Response<GetByIdUserResponse>>
    {
        #region fields
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        #endregion


        #region constructors
        public UserHandlersQuery(IMapper mapper, UserManager<User> userManager) : base()
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }
        #endregion

        #region handle function
        public async Task<PaginatedResult<GetPaginationUserResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = userManager.Users.AsQueryable();
          
          
            var mapUser = await mapper.ProjectTo<GetPaginationUserResponse>(users).ToPaginatedListAsync(request.PageNumber,request.PageSize);
            return mapUser;
        }

        public async Task<Response<GetByIdUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        { var user =  userManager.Users.FirstOrDefault(u => u.Id == request.Id);
            if (user == null)
                return NotFound<GetByIdUserResponse>($"this user {request.Id} Not Fount ");
            var mappedUser = mapper.Map<GetByIdUserResponse>(user);

            return Success(mappedUser);
        }
        #endregion


    }
}
