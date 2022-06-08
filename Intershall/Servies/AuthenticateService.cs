﻿using Intershall.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Intershall.Servies
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        public AuthenticateService(IOptions<AppSettings> appSettings)
        { 
            _appSettings = appSettings.Value;
        }
        private List<User> users = new List<User>()
        {
          new User{ 
              UserId=1,FirstName="Nikita",LastName="Jaiswal",
              Email="jaiswalnikita23@gmail.com",
              Password="Nikki@123",Isactive="Y",Roles="User"
          }
        };


        public User Authenticate(string Email, string Password)
        {
           var user = users.SingleOrDefault(x => x.Email == Email && x.Password == Password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserId.ToString()),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Version,"V3.1")
                }),
                Expires=DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };
            var  token=tokenHandler.CreateToken(tokenDescriptor);

            user.Token=tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }
    }
}
