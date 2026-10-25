using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.AbstractServices;

namespace SchoolProject.Service.Implementation
{
    public class StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger) : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly ILogger<StudentService> _logger = logger;
        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
        public async Task<Student?> GetStudentByIDWithIncludeAsync(int id)
        {
            return await _studentRepository.GetTableNoTracking()
                                          .Include(x => x.Department)
                                          .FirstOrDefaultAsync(x => x.StudID.Equals(id));
        }
        public async Task<string> AddAsync(Student student)
        {
            //Added Student
            await _studentRepository.AddAsync(student);
            return "Success";
        }
        public async Task<bool> IsNameArExist(string nameAr)
        {
            //Check if the name is Exist Or not
            return await _studentRepository.GetTableNoTracking().AnyAsync(x => x.NameAr == nameAr);
        }
        public async Task<bool> IsNameEnExist(string nameEn)
        {
            //Check if the name is Exist Or not
            return await _studentRepository.GetTableNoTracking().AnyAsync(x => x.NameEn == nameEn);
        }
        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            return await _studentRepository.GetTableNoTracking()
                                          .AnyAsync(x => x.NameAr == nameAr && x.StudID != id);
        }
        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            return await _studentRepository.GetTableNoTracking()
                                          .AnyAsync(x => x.NameEn == nameEn && x.StudID != id);
        }
        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }
        public async Task<string> DeleteAsync(Student student)
        {
            await using var trans = await _studentRepository.BeginTransactionAsync();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                _logger.LogError(ex, "Failed to delete the student: {Message}", ex.Message);
                return "Failed";
            }

        }
        public async Task<Student?> GetByIDAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }
        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }
        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(DID)).AsQueryable();
        }
        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnums orderingEnum, string? search)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => (x.NameAr != null && x.NameAr.Contains(search))
                                          || (x.Address != null && x.Address.Contains(search)));
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnums.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnums.Name:
                    querable = querable.OrderBy(x => x.NameAr);
                    break;
                case StudentOrderingEnums.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnums.DepartmentName:
                    querable = querable.OrderBy(x => x.Department!.DNameAr);
                    break;
            }

            return querable;
        }
        #endregion
    }
}
