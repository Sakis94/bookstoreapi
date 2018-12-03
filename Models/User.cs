using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Models
{
    public class User : IdentityUser, IEntity {
        public string FirstName { get; set; }
        public string LastName { get; set; }
	}
}