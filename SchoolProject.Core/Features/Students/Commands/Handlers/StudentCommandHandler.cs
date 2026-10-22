using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.AbstractServices;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler(IStudentService service, IMapper mapper)
        : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
        , IRequestHandler<EditStudentCommand, Response<string>>
        , IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Handle function
        public async Task<Response<string>>
            Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = mapper.Map<Student>(request);
            var result = await service.AddAsync(studentMapper);
            if (result == "Success")
                return Created("Added Successfully");
            return BadRequest<string>(result);
        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {

            var e = await service.GetStudentByIDWithIncludeAsync(request.StudID);
            if ((e == null))
            {
                return NotFound<string>("Student Not Exist");
            }
            var studentMapper = mapper.Map<Student>(request);
            var result = await service.EditAsync(studentMapper);
            if (result == "Success")
                return Success("Updated  Successfully");
            else return BadRequest<string>(result);
        }
        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var s = await service.GetByIDAsync(request.StudID);
            if (s == null)
            {
                return NotFound<string>("Student Not Exist");
            }
            var result = await service.DeleteAsync(s);
            if (result == "Success")
                return Deleted<string>($"Deleted Successfully {request.StudID}");
            else return BadRequest<string>(result);
        }
        #endregion
    }
}
