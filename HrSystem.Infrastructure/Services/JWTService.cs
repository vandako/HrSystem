/*using HrSystem.Core.DTOs;
using HrSystem.Core.DTOs;
using HrSystem.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;

//using System.IdentityModel.Tokens;
using Microsoft.IdentityModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
//using System.IdentityModel.Tokens.Jwt;

namespace CustomerForms.Infrastructure.Services
{
    public class JWTService : IJWTService
    {

        private readonly IConfiguration iconfiguration;
        public JWTService(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;

        }

        public string GenerateToken(AppUserDto user)
        {
            // Else we generate JSON Web Token
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["AuthConfig:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                 new Claim(ClaimTypes.Name,  $"{user.LastName} {user.FirstName}"),
                 new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
              //  new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),



              }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var TheToken = tokenHandler.WriteToken(token);
            var exp = token.ValidTo;
            return TheToken;
        }
    }
}*/