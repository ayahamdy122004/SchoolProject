using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Results;
using SchoolProject.Service.AbstractServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
   public class AUthenticationService:IAUthenticationService
    {
        #region fields
        private readonly JwtSettings jwtSettings;
        #endregion

        #region constructors
        public AUthenticationService(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
            
        }
        #endregion

        #region handle functions
        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var claims = new List<Claim>()
    {
        new Claim(nameof(UserClaimModel.UserName), user.UserName),
        new Claim(nameof(UserClaimModel.Email), user.Email),
        new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
    };

            var jwtToken = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            // الحل هنا: إرجاع الكائن مغلفاً في JwtAuthResult (حسب هيكل الكلاس لديكِ)
            var response = new JwtAuthResult
            {
                AccessToken = accessToken,
                // إذا كان هناك RefreshToken أو خصائص أخرى يتم تعبئتها هنا أيضاً
            };

            return response;
        }


        #endregion
    }
}
