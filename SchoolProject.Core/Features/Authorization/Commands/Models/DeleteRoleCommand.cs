

using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
   public class DeleteRoleCommand: IRequest<Response<string>>
    {
        public string RoleId { get; set; }
        public DeleteRoleCommand(string RoleId)=>this.RoleId=RoleId;

    }
}
