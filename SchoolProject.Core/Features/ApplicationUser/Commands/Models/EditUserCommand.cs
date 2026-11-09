using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
   public class EditUserCommand : IRequest<SchoolProject.Core.Bases.Response<string>>
    {
        public string Id    { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }

    }
  
}
