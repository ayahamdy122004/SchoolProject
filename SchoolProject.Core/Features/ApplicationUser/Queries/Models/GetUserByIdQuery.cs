using MediatR;
using SchoolProject.Core.Features.ApplicationUser.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Models
{
   public  class GetUserByIdQuery:IRequest<SchoolProject.Core.Bases.Response<GetByIdUserResponse>>
    {
        public string Id { get; set; }
        public GetUserByIdQuery(string Id)
        {
            this.Id = Id;
        }
    }
}
