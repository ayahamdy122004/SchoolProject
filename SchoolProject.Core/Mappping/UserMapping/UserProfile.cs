using AutoMapper;

namespace SchoolProject.Core.Mappping.UserMapping
{
    public partial class UserProfile:Profile
    {
        public UserProfile()
        {
            AddUserCommandMapping();
            GetByIdQueryMapping();
            PaginationUserQueryMpping();
        }
    }
}
