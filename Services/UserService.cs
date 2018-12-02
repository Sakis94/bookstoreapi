using System;
using Microsoft.Extensions.Configuration;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

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

        public User GetUserByUsername( string username ){
            return new User();
        }

        public void CreateUser( User user ){
            var result = _dbService.Users.Add(user);
        }

        public void LogoutUser( ObjectId id )
        {
            // 
        }

        public string GenerateSession( User user ){
            return "";
        }

    }

   
}