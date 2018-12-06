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

		public UserDTO Login(UserDTO input){

			var user = this.GetUser(new BsonDocument { { "UserName", input.UserName } });
			var password = this.HashPassword(input.Password);

			if (user == null){
				return null;
			}
			else if (user.PasswordHash != password){
				return null;
			}
			else {
				var userData = new UserDTO { Id = user.Id, UserName = user.UserName, FirstName = user.FirstName, LastName = user.LastName };
				return userData;
			}
		}

		public bool Register(UserDTO input){

			var user = this.GetUser(new BsonDocument { { "UserName", input.UserName } });

			if (user == null){
				user = new User
				{
					UserName = input.UserName,
					FirstName = input.FirstName,
					LastName = input.LastName,
					PasswordHash = this.HashPassword(input.Password)
				};

				_dbService.Users.Add(user);
				return true;
			}
			else {
				return false;
			}
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