using SchoolProject.Core.Features.Students.Queries.Results;
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
        public void GetStudentByIdMapping() 
        {
            CreateMap<Student, GetSingleStudentResponse>().
                ForMember(des => des.DepartmentName,
                    opt => opt.MapFrom(scr => scr.Department.DName));
        }
    }
}
