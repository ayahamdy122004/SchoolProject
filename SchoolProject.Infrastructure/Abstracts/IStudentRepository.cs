using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Task<List<Student>> GetAllStudentsAsync();
        //Task<Student> GetStudentByIdAsync(int id);
        //Task AddStudentAsync(Student student);
        //Task UpdateStudentAsync(Student student);
        //Task DeleteStudentAsync(int id);
    }
}
