using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.AbsrractServices;
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
        private readonly IStudentService _studentService;
        #endregion
        #region Constructors
        public AddStudentValidator(IStudentService _studentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();  
            this._studentService = _studentService;
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .NotNull().MaximumLength(10).WithMessage("Max Lenght is 10");


            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} is required.").NotNull()
                .WithMessage("{PropertyValue}is required.").MaximumLength(50).WithMessage("Max Lenght is 50")  
               ;

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
            RuleFor(x => x.DID).NotNull().WithMessage("DID is required.");
        }
        public void ApplyCustomValidationRules()
        {
            // Add custom validation rules here if needed
           RuleFor(x => x.Name).MustAsync(async (Key, cancellation) =>!await _studentService.IsNameExist(Key))
                .WithMessage("Name is already exist.");

        }
        #endregion
    }
}
