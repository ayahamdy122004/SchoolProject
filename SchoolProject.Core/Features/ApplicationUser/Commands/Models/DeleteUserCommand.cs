
using MediatR;


namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand:IRequest<SchoolProject.Core.Bases.Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int Id)
        {
            this.Id= Id;    
        }
    }
}
