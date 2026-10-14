using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mappping.StudentMapping
{
    public partial class StudentProfile
    {
        public void EditStudentCommendMapping() => CreateMap<EditStudentCommand, Student>().ForMember(des=>des.StudID,opt=>opt.Ignore());
    }
}
