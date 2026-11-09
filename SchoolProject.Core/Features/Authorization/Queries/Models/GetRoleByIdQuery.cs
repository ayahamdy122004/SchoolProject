using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery:IRequest<Response<GetRoleByIdResponse>>
    {
        public string RoleId { get; set; }
        public GetRoleByIdQuery(string roleId)
        {
            RoleId = roleId;
        }
    }
}
