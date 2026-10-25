using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mappping.DepartmentMapping
{
    public partial class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            //GetDepartmentListMapping();
            GetDepartmentByIdMapping();
            //AddDepartmentCommandMapping();
            //EditDepartmentCommendMapping();
        }
    }
}
