using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authenication.Commands.Models;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{

    [ApiController]
    public class AuthorozationsController : AppControllerBase
    {
        #region fields
        private readonly IMediator mediator;
        #endregion

        #region constructors
        public AuthorozationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion
        [HttpPost(Router.Authorization.Add)]
        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }
        [HttpPost(Router.Authorization.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Router.Authorization.Delete)]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var response = await mediator.Send(new DeleteRoleCommand(roleId));
            return NewResult(response);
        }

        [HttpGet(Router.Authorization.List)]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await mediator.Send(new Core.Features.Authorization.Queries.Models.GetRoleListQuery());
            return Ok(response);
        }

        [HttpGet(Router.Authorization.GetByID)]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            var response = await mediator.Send(new GetRoleByIdQuery(roleId));
            return NewResult(response);
        }

    }
}
