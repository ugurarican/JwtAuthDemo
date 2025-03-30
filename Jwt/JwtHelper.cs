﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthDemo.Jwt
{
    public class JwtHelper
    {
        public static string GenerateJwt(JwtDto jwtInfo) 
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SecretKey));
            var credentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Id", jwtInfo.Id.ToString()),
                new Claim("Email",jwtInfo.Email),
                new Claim("UserType",jwtInfo.UserType.ToString()),

                //Yetkilendirme için
                new Claim(ClaimTypes.Role, jwtInfo.UserType.ToString())
            };
            var expiraTime = DateTime.Now.AddMinutes(jwtInfo.ExpireMinute);
            var tokenDescriptor = new JwtSecurityToken(jwtInfo.Issuer, jwtInfo.Audience, claims, null, expiraTime, credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return token;
        }
    }
}
