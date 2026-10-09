using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using SchoolProject.Service.AbsrractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler,IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
    {
        #region field
        private readonly IStudentService service;
        private readonly IMapper mapper;
        #endregion
        #region constructor
        public StudentHandler(IStudentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        #endregion
        #region endpoints
        public async Task<Response<List<GetStudentListResponse>>>
         Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await service.GetAllStudents();
            var response = mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(response);
        }

        public async Task<Response<GetSingleStudentResponse>> 
            Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await service.GetStudentById(request.Id);
            if (student == null)
            {
                return NotFound<GetSingleStudentResponse>("Student not found");
            }

            var response = mapper.Map<GetSingleStudentResponse>(student);
            return Success(response);
        }
        #endregion



    }
}
