using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

using Models;
using Dtos;

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

        public bool Logout( ObjectId id )
        {
			return true;
        }

        public string GenerateSession( User user ){
            return "";
        }

		public UserResponse Login( User input ){

			var user = this.GetUser(new BsonDocument { { "UserName", input.UserName } });
			input.Password = this.HashPassword(input.Password);

			if( user == null ){
				return new UserResponse { ErrorLevel = UserResponse.ERROR_USERNAME, ErrorMessage = UserResponse.ERROR_MSG_USERNAME };
			} else if( user.Password != input.Password ){
				return new UserResponse { ErrorLevel = UserResponse.ERROR_PASSWORD, ErrorMessage = UserResponse.ERROR_MSG_PASSWORD };
			} else {
				var userData = new UserDto {};
				return new UserResponse { ErrorLevel = UserResponse.ERROR_PASSWORD, ErrorMessage = UserResponse.ERROR_MSG_PASSWORD, UserData = userData };
			}
		}

		public void Register( User user ){
            var result = _dbService.Users.Add(user);
        }

		public User GetUser( BsonDocument filters ){
			var results = _dbService.Users.Get(filters);
			if( results.Count <= 0 ){
				return null;
			} else {
				return results[0];
			}
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