namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse(int StudID, string? NameAr, string? NameEn, string? Address, string? DepartmentName)
    {
        public int StudID { get; set; } = StudID;

        public string? NameAr { get; set; } = NameAr;

        public string? NameEn { get; set; } = NameEn;

        public string? Address { get; set; } = Address;

        public string? DepartmentName { get; set; } = DepartmentName;
    }
}
