using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository(AppDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepository
    {
        #region Fields
        private readonly DbSet<Department> _departments = dbContext.Set<Department>();
        #endregion

        #region Handle Functions

        #endregion
    }
}
