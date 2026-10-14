using AutoMapper;
using Azure.Core;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.AbsrractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler
        :ResponseHandler,IRequestHandler<AddStudentCommand,Response<string>>
        ,IRequestHandler<EditStudentCommand,Response<string>>
    {
       
        #region field
        private readonly IStudentService service;
        private readonly IMapper mapper;

        #endregion
        #region consttructure
        public StudentCommandHandler(IStudentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        #endregion
        #region Handle function
        public async Task<Response<string>> 
            Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper =  mapper.Map<Student>(request);
            var result=await service.Add(studentMapper);
             if(result=="Success")  
                return Created("Added Successfully");   
             return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {

            var e = await service.GetStudentById(request.StudID);
            if ((e == null))
            {
                return NotFound<string>("Student Not Exist");
            }
            var studentMapper = mapper.Map<Student>(request);
            var result = await service.EditAsync(studentMapper);
            if( result=="Seccuss")
                return Success("Updated  Successfully");
            else return BadRequest<string>(result); 
        }


        #endregion


        // var result = await service.Update(studentMapper);
    }
}
