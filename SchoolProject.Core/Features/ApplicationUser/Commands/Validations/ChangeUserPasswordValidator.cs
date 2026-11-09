using FluentValidation;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validatiors
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Fields
       
        #endregion

        #region Constructors
        public ChangeUserPasswordValidator()
        {
           
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("this field is required")
                .NotNull().WithMessage("this field is required");

            RuleFor(x => x.CurrentPassword)
                 .NotEmpty().WithMessage("this field is required")
                 .NotNull().WithMessage("this field is required");
            RuleFor(x => x.NewPassword)
                 .NotEmpty().WithMessage(("this field is required"))
                 .NotNull().WithMessage("this field is required");
            RuleFor(x => x.ConfirmNewPassword)
                 .Equal(x => x.NewPassword).WithMessage($"this field must be match NewPassword  !!!!!!!!!! ");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}