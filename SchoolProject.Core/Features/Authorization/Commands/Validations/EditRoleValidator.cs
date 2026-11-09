using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;
namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields
      
        #endregion
        #region Constructors

        #endregion
        public EditRoleValidator()
        {
          
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.roleId)
                 .NotEmpty().WithMessage("This Field is Required")
                 .NotNull().WithMessage("This Field is Required");

            RuleFor(x => x.roleName)
                 .NotEmpty().WithMessage("This Field is Required")
                 .NotNull().WithMessage("This Field is Required");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}