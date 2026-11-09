using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Service.AbstractServices;
namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
    public class AddRoleValidators : AbstractValidator<AddRoleCommand>
    {
        #region Fields
      
        private readonly IAuthorizationservice _authorizationService;
        #endregion
        #region Constructors

        #endregion
        public AddRoleValidators(IAuthorizationservice authorizationService)
        {
            
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.RoleName)
                 .NotEmpty().WithMessage("this is field required!!!!!!!")
                 .NotNull().WithMessage("this is field required!!!!!!!");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.isNameRoleExist(Key))
                .WithMessage("this is field required!!!!!!!");
        }

        #endregion
    }
}