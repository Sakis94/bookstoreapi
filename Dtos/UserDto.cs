using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

using Models;

namespace Dtos
{
	public class UserDto : Entity
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string SessionId { get; set; }
	}
}
