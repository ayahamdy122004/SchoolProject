using MediatR;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand(int id) : IRequest<SchoolProject.Core.Bases.Response<string>>
    {
        public int StudID { get; set; } = id;
    }
}
