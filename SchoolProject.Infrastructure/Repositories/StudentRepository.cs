using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext db;
        public StudentRepository(AppDbContext db)
        {
            this.db = db;
        }
       public async Task<List<Student>> GetAllStudentsAsync()
        {
           return await db.Students.ToListAsync();
        }
    }
}
