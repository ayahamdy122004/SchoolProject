using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Entities;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using static System.Net.WebRequestMethods;
namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentsController : AppControllerBase
    {
        private readonly IMediator mediator;
        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
         var result = await mediator.Send(new GetStudentListQuery()); 
            return Ok(result);
        }

        [HttpGet(Router.StudentRouting.GetByID)]
        // GET: api/Students/5   for example, to get a student with ID 5 from Route parameter
        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var result = await mediator.Send(new GetStudentByIdQuery(id));
                return Ok(result);
        }
        [HttpPost(Router.StudentRouting.Add)]
        public async Task<IActionResult> AddStudent(AddStudentCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);

        }

    }
}
