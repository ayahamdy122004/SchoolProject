using Azure;
using MediatR;
using SchoolProject.Core.Features.Students.Commands.ResultCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Core.Bases;
namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public  class EditStudentCommand : IRequest<SchoolProject.Core.Bases.Response<string>>
    {
        public int StudID { get; set; }
  
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
      
        public string? Phone { get; set; }
        public int? DID { get; set; }
    }
}
