using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Service.AbstractServices;
namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Fields

        public readonly IAuthorizationservice _authorizationService;

        #endregion
        #region Constructors
        public DeleteRoleValidator( IAuthorizationservice authorizationService)
        {
       
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region  Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.RoleId)
                 .NotEmpty().WithMessage("Id must not be empty")
                 .NotNull().WithMessage("Id is required");
        }
        public void ApplyCustomValidationsRules()
        {
            //RuleFor(x => x.Id)
            //    .MustAsync(async (Key, CancellationToken) => await _authorizationService.IsRoleExistById(Key))
            //    .WithMessage(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
        }
        #endregion
    }
}