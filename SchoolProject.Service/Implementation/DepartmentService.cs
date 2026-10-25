using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.AbstractServices;
using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        #region fields
        private readonly IDepartmentRepository repo;
        #endregion

        #region  constructors
        public DepartmentService(IDepartmentRepository repo)
        {
            this.repo = repo;
            
        }
        #endregion


        #region methods
        public async  Task<Department> GetDepartmentById(int id)
        {

            var student = await repo.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                      .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                                                      .Include(x => x.Instructors)
                                                      .Include(x => x.Instructor).FirstOrDefaultAsync();
            return student;
        }
        #endregion

    }
}
