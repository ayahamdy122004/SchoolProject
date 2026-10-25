using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Quaries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
using System.Threading.Tasks;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : AppControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentById([FromForm] GetDepartmentByIdQuery query)
        {
            var result = await mediator.Send(query);
            return NewResult(result);
        }
    }
}
