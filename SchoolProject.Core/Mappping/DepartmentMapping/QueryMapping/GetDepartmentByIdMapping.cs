using AutoMapper;   
using SchoolProject.Core.Features.Departments.Quaries.Results;
using SchoolProject.Data.Entities;
using static SchoolProject.Core.Features.Departments.Quaries.Results.GetSingleDepartmentResponse;

namespace SchoolProject.Core.Mappping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetSingleDepartmentResponse.GetDepartmentByIDResponse>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DNameEn))
                 .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DID))
                 .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor != null ? src.Instructor.ENameEn : null))
                 .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                 .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmetSubjects, SubjectResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.SubjectNameEn));

            //CreateMap<Student, StudentResponse>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameEn));
            CreateMap<Instructor, InstructorResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ENameEn));
        }
    }
}