using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace Models
{
	public class User : IdentityUser<Guid>, IEntity
	{

		public override Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}