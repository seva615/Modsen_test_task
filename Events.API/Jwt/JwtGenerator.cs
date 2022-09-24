using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modsen_test_task.ViewModels;

namespace Modsen_test_task.Jwt
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IOptions<AuthOptions> _authOptions;

        public JwtGenerator(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions;
        }

        public string GenerateJwtToken(OrganizerViewModel organizer)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.GivenName, organizer.Name),
                new Claim(JwtRegisteredClaimNames.Sub, organizer.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, organizer.Role)
            };
            //claims.AddRange(organizer.Role.Select(role => new Claim("role", organizer.Role)));

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claimsIdentity.Claims.ToList(),
                expires: DateTime.Now.AddMinutes(240),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}