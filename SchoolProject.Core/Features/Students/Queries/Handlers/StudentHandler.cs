using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.AbstractServices;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler(IStudentService service, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
        IRequestHandler<GetStudentPaginationListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region endpoints
        public async Task<Response<List<GetStudentListResponse>>>
         Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await service.GetStudentsListAsync();
            var response = mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(response);
        }

        public async Task<Response<GetSingleStudentResponse>>
            Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await service.GetStudentByIDWithIncludeAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetSingleStudentResponse>("Student not found");
            }

            var response = mapper.Map<GetSingleStudentResponse>(student);
            return Success(response);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>>
            Handle(GetStudentPaginationListQuery request, CancellationToken cancellationToken)

        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new
            GetStudentPaginatedListResponse(e.StudID, e.NameAr, e.NameEn, e.Address, e.Department.DNameAr);
            var filteredQueryable = service.FilterStudentPaginatedQueryable(request.OrderedBy, request.SearchBy);
            var quarable = await filteredQueryable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return quarable;
        }
        #endregion
    }
}
