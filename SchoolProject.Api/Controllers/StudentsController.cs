using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.Models;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using static System.Net.WebRequestMethods;
namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;
        public StudentsController(IMediator mediator)
        {
           this.mediator = mediator;
        }
        [HttpGet("Student/List")]
        public async Task<IActionResult> GetStudentList()
        {
         var result = await mediator.Send(new GetStudentListQuery()); 
            return Ok(result);
        }
    }
}
