using AutoMapper;

namespace SchoolProject.Core.Mappping.StudentMapping
{
    public partial class StudentProfile:Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentCommandMapping();
            EditStudentCommendMapping();
        }
    }
}
