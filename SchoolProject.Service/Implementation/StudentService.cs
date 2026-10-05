using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.AbsrractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
        }
        public async Task<List<Student>> GetAllStudents()
        {
           return await repo.GetAllStudentsAsync();
        }
    }
}
