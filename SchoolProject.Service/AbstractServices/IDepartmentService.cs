using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.AbstractServices
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);
    }
}
