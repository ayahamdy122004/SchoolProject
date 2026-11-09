using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
namespace SchoolProject.Api.Controllers
{
   
    [ApiController]
    public class ApplicatonUsersController :AppControllerBase
    {
        #region fields
        private readonly IMediator mediator;

     

       
        #endregion

        #region constructors
        public ApplicatonUsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion

        #region handle endpoints
        //  [HttpGet(Router.DepartmentRouting.GetByID)]
        [HttpPut(SchoolProject.Data.AppMetaData.Router.AppicationUserRouting.Add)]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            var res = await mediator.Send(command);
            return NewResult(res);
        }

        [HttpPut(SchoolProject.Data.AppMetaData.Router.AppicationUserRouting.Edit)]
        public async Task<IActionResult> EditUser(EditUserCommand command)
        {
            var res = await mediator.Send(command);
            return NewResult(res);
        }

        [HttpGet(SchoolProject.Data.AppMetaData.Router.AppicationUserRouting.Paginad)]
        public async Task<IActionResult> GetAllUsers()
        {
            var res = await mediator.Send(new GetUserPaginationQuery());
            return Ok(res);
        }

        [HttpGet(SchoolProject.Data.AppMetaData.Router.AppicationUserRouting.GetByID)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var res = await mediator.Send(new GetUserByIdQuery(id));
            return NewResult(res);
        }
        [HttpDelete(SchoolProject.Data.AppMetaData.Router.AppicationUserRouting.Delete)]
        public async Task<IActionResult> DeleteUser([FromRoute] DeleteUserCommand delete)
        {
            var res = await mediator.Send(new DeleteUserCommand(delete.Id));
            return NewResult(res);
        }
        #endregion
    }
}
