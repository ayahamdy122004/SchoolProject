using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.data;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository :GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext db;
        private readonly DbSet<Student> students;
        public StudentRepository(AppDbContext db): base(db)  
        {
            this.db = db;
            students = db.Students; 
        }
       public async Task<List<Student>> GetAllStudentsAsync()
        {
           //return await db.Students.Include(s => s.Department).
           //     ToListAsync();
           return await students.Include(x=>x.Department).ToListAsync();
        }
    }
}
