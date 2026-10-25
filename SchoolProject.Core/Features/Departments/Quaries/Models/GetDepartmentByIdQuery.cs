using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Quaries.Results;

namespace SchoolProject.Core.Features.Departments.Quaries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetSingleDepartmentResponse.GetDepartmentByIDResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }
    }
}

