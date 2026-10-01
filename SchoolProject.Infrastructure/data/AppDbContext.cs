using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
   public DbSet<SchoolProject.Data.Entities.Student> Students { get; set; }
        public DbSet<SchoolProject.Data.Entities.Department> Departments { get; set; }
        public DbSet<SchoolProject.Data.Entities.Subject> Subjects { get; set; }
        public DbSet<SchoolProject.Data.Entities.StudentSubject> StudentSubjects { get; set; }
        public DbSet<SchoolProject.Data.Entities.DepartmetSubject> DepartmentSubjects { get; set; }

    }



}