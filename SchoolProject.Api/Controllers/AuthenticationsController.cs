using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Core.Features
            .Authenication.Commands.Models;

namespace SchoolProject.Api.Controllers
{
  
    [ApiController]
    public class AuthenticationsController : AppControllerBase
    {
        #region fields
        private readonly IMediator mediator;




        #endregion

        #region constructors
        public AuthenticationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }
    }
}
