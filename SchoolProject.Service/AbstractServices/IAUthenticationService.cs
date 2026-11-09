
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Results;

namespace SchoolProject.Service.AbstractServices
{
  public interface IAUthenticationService
    {
        Task<JwtAuthResult> GetJWTToken(User user);
    }
}
