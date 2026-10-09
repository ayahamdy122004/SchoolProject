using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator :AbstractValidator<AddStudentCommand>
    {
        #region fields
        #endregion
        #region Constructors
        public AddStudentValidator()
        {
            
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .NotNull().MaximumLength(10).WithMessage("Max Lenght is 10");


            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.").NotNull()
                .WithMessage("{ }is required.").MaximumLength(50).WithMessage("Max Lenght is 50")  
               ;

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
            RuleFor(x => x.DID).NotNull().WithMessage("DID is required.");
        }
        #endregion
    }
}
