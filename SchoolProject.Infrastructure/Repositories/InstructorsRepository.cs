using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorsRepository(AppDbContext dbContext) : GenericRepository<Instructor>(dbContext), IInstructorsRepository
    {
        #region Fields
        private readonly DbSet<Instructor> _instructors = dbContext.Set<Instructor>();
        #endregion

        #region Handle Functions

        #endregion
    }
}
