using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authenication.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Results;
using SchoolProject.Service.AbstractServices;


namespace SchoolProject.Core.Features.Authenication.Commands.Handlers
{
    internal class AuthenticationHandlerCommand : ResponseHandler, IRequestHandler<SignInCommand, Response<JwtAuthResult>>
    {
        #region fields
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IAUthenticationService service;
        #endregion

        #region ctor
        public AuthenticationHandlerCommand(Microsoft.AspNetCore.Identity.UserManager<User> userManager, SignInManager<User> signInManager, IAUthenticationService service)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.service = service;
        }
        #endregion



        #region handles functions
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await userManager.FindByNameAsync(request.UserName);
            //Return The UserName Not Found
            if (user == null) return BadRequest<JwtAuthResult>();
            //try To Sign in 
            var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>();
            //confirm email
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResult>();
            //Generate Token
            var result = await service.GetJWTToken(user);
            //return Token 
            return Success(result);
        }

        #endregion

    }


}
