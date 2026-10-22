using MediatR;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginationListQuery:IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageSize { get; set; }   
        public int PageNumber { get; set; } 
        public StudentOrderingEnums OrderedBy { get; set; }
        public string ?SearchBy { get; set; }
    }
}
