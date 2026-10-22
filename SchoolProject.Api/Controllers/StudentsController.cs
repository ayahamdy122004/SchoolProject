using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Entities;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using static System.Net.WebRequestMethods;
namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IMediator mediator) : AppControllerBase   
    {
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
         var result = await mediator.Send(new GetStudentListQuery()); 
            return NewResult(result);
        }

      
        [HttpGet(Router.StudentRouting.Paginad)]
        public async Task<IActionResult> Paginted([FromQuery] GetStudentPaginationListQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var result = await mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(result);
        }
        [HttpPost(Router.StudentRouting.Add)]
        public async Task<IActionResult> AddStudent(AddStudentCommand command)
        {
            var res = await mediator.Send(command);
            return NewResult(res);
        }
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent(EditStudentCommand command)
        {
            var res = await mediator.Send(command);
            return NewResult(res);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var res = await mediator.Send(new DeleteStudentCommand(id));
            return NewResult(res);
        }

    }
}
