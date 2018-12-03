using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

using Models;
using System.Security.Cryptography;
using System.Text;

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
			var filters = new BsonDocument { { "Username", username } };
			var results = _dbService.Users.Get(filters);
			if( results.Count > 0 ){
				return results[0];
			}
			return new User();
        }

        public void CreateUser( User user ){
            var result = _dbService.Users.Add(user);
        }

        public bool Logout( ObjectId id )
        {
			return true;
        }

        public string GenerateSession( User user ){
            return "";
        }

		public bool Login( string inputPasswd, string dbPasswd ){
			return this.HashPassword(inputPasswd) == dbPasswd;
		}

		private string HashPassword( string input ){

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