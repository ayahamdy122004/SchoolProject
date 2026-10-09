using Microsoft.EntityFrameworkCore;
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
        #region fields
        private readonly IStudentRepository repo;
        #endregion
        #region field constructor
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
        }
        #endregion
        #region function
        public async Task<string> Add(Student student)
        {
            var studentResult = await repo.GetTableNoTracking().
                Where(x => x.Name.Equals(student.Name)).FirstOrDefaultAsync();
            if (studentResult != null)
                return "Name is Exist!!!!!";

            await repo.AddAsync(student);
            return "Success";
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await repo.GetAllStudentsAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            //  return await repo.GetByIdAsync(id);
            var student = await repo.GetTableNoTracking().Include(x => x.Department)
                    .FirstOrDefaultAsync(x => x.StudID == id);
            return student;
        }
        #endregion

    }
}
