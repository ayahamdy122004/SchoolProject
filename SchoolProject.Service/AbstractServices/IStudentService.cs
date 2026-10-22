using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.AbstractServices
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync();
        Task<Student?> GetStudentByIDWithIncludeAsync(int id);
        Task<Student?> GetByIDAsync(int id);
        Task<string> AddAsync(Student student);
        Task<bool> IsNameArExist(string nameAr);
        Task<bool> IsNameEnExist(string nameEn);
        Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        Task<string> EditAsync(Student student);
        Task<string> DeleteAsync(Student student);
        IQueryable<Student> GetStudentsQueryable();
        IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnums orderingEnum, string? search);
    }
}
