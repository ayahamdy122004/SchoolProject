using FluentValidation;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validatiors
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
   
        #endregion

        #region Constructors
        public AddUserValidator()
        {
            
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage("This Field i Required")
                 .NotNull().WithMessage("This Field i Required")
                 .MaximumLength(100).WithMessage("Max Length is 100");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("This Field i Required")
                .NotNull().WithMessage("This Field i Required")
                .MaximumLength(100).WithMessage("Max Length is 100");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("This Field i Required")
                 .NotNull().WithMessage("This Field i Required");
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("This Field i Required")
                 .NotNull().WithMessage("This Field i Required" );
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage("this field must be equal to Password");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}