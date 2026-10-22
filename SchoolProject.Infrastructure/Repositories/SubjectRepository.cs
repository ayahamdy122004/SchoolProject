using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository(AppDbContext dbContext) : GenericRepository<Subject>(dbContext), ISubjectRepository
    {
        #region Fields
        private readonly DbSet<Subject> _subjects = dbContext.Set<Subject>();
        #endregion

        #region Handle Functions

        #endregion
    }
}
