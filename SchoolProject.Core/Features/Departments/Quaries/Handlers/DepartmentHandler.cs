using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Quaries.Models;
using SchoolProject.Core.Features.Departments.Quaries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.AbstractServices;
using SchoolProject.Service.Implementation;
using System.Linq.Expressions;
using static SchoolProject.Core.Features.Departments.Quaries.Results.GetSingleDepartmentResponse;
namespace SchoolProject.Core.Features.Departments.Quaries.Handlers
{
    public class DepartmentHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetSingleDepartmentResponse.GetDepartmentByIDResponse>>
    {
        #region fields
        private readonly IDepartmentService service ;
        private readonly IStudentService _studentService;
        private readonly IMapper mapper;
        #endregion

        #region  constructors
        public DepartmentHandler(IDepartmentService service, IMapper mapper, IStudentService studentService )
        {
            this.service = service;
            this.mapper = mapper;
            _studentService = studentService;
        }
        #endregion


        #region methods
        public async Task<Response<GetSingleDepartmentResponse.GetDepartmentByIDResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            //service Get By Id include St sub ins
            var response = await service.GetDepartmentById(request.Id);
            //check Is Not exist
            if (response == null) return NotFound<GetSingleDepartmentResponse.GetDepartmentByIDResponse>($"this department {request.Id} Not Found1");
            //mapping 
            var mapper1 = mapper.Map<GetSingleDepartmentResponse.GetDepartmentByIDResponse>(response);

            //pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.NameEn);
            var studentQuerable = _studentService.GetStudentsByDepartmentIDQuerable(request.Id);
            var paginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper1.StudentList = paginatedList;

            //return response
            return Success(mapper1);
        }


        #endregion
    }
}
