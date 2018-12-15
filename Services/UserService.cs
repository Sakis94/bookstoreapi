using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

using Models;
using Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookstoreapi.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Services
{

    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly DBService _dbService;

        public UserService(IConfiguration configuration, DBService dbService)
        {
            _configuration = configuration;
            _dbService = dbService;
        }

        public bool Logout(ObjectId id)
        {
            return true;
        }

        public string GenerateSession(User user)
        {
            return "";
        }

        public JwtSecurityToken Login(LoginViewModel input)
        {

            var user = this.GetUser(new BsonDocument { { "Username", input.Username } });
            var password = this.HashPassword(input.Password);

            if (user == null)
            {
                return null;
            }
            else if (user.PasswordHash != password)
            {
                return null;
            }
            else
            {

                var claims = new List<Claim>();

                claims.Add(new Claim("Id", user.Id.ToString()));
                claims.Add(new Claim("Name", user.Username));
				claims.Add(new Claim(ClaimTypes.Role, "admin"));

				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                  _configuration["Tokens:Issuer"],
                  _configuration["Tokens:Issuer"],
                  claims,
                  expires: DateTime.UtcNow.AddMinutes(560),
                  signingCredentials: creds);

                return token;
            }
        }

        public User Register(User input)
        {
            var user = this.GetUser(new BsonDocument { { "UserName", input.Username } });

            if (user == null)
            {
                user = new User
                {
                    Username = input.Username,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email,
                    PasswordHash = this.HashPassword(input.Password)
                };
                var result = _dbService.Users.Add(user);
                return result;
            }
            return null;
        }

        public User GetUser(BsonDocument filters)
        {
            var results = _dbService.Users.Get(filters);
            if (results.Count <= 0)
            {
                return null;
            }
            else
            {
                return results[0];
            }
        }

        private string HashPassword(string input)
        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }


}