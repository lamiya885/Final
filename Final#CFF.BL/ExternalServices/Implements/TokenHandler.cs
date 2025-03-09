using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.CommonDTOs;
using Final_CFF.BL.ExternalServices.Abstracts;
using Final_CFF.BL.Helpers;
using Final_CFF.Core.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Final_CFF.BL.ExternalServices.Implements
{
    public class TokenHandler : ITokenHandler
    {
        readonly JwtOptions opt;
        public TokenHandler(IOptions<JwtOptions> _opt)
        {
            opt = _opt.Value;
        }
        public string CreateToken(JwtDTO DTO, int hours = 36)
        {
            List<Claim> claims = [
                new Claim(ClaimTypes.Name, DTO.UserName),
            new Claim(ClaimTypes.Email, DTO.Email),
            new Claim(ClaimTypes.Role,DTO.Role.ToString()),
            new Claim("FullName",DTO.FullName)
            ];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.SecretKey));
            SigningCredentials cred = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken secToken = new(
                issuer: opt.Issuer,
                audience: opt.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: cred
            );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }

        //    public string CreateToken(JwtDTO DTO )
        //    {
        //        string issuer = _configuration["Jwt:Issuer"]!;
        //        string audience = _configuration["Jwt:Audience"]!;
        //        string secretKey = _configuration["Jwt:SecretKey"]!;


        //        List<Claim> claims =
        //        [
        //             new Claim(ClaimTypes.Name,DTO.UserName),
        //         new Claim(ClaimTypes.Email,DTO.Email),
        //         new Claim(ClaimTypes.Role,DTO.Role.ToString()),
        //         new Claim("FullName",DTO.FullName),
        //        ];

        //        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        //        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        JwtSecurityToken jwtSec = new JwtSecurityToken(
        //            issuer: issuer,
        //            audience: audience,
        //            claims: claims,
        //            notBefore: DateTime.UtcNow,
        //            expires: DateTime.UtcNow.AddDays(1)
        //            );
        //        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //        return handler.WriteToken(jwtSec);  
        //    }
        //}
    }
}
