using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository(AppDbContext db) : GenericRepository<Student>(db), IStudentRepository
    {
        private readonly DbSet<Student> _students = db.Students;

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _students.Include(x => x.Department).ToListAsync();
        }
    }
}
