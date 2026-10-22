using MediatR;
using SchoolProject.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<SchoolProject.Core.Bases.Response<string>>
    {
        // public int StudID { get; set; }
        [Required]
        public string NameAr { get; set; } = null!;
        public string? NameEn { get; set; }
        [Required]
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? DID { get; set; }
    }
}
