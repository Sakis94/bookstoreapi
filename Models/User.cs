using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Models
{
    public class User : IdentityUser, IEntity
	{
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Password { get; set; }

        public bool ValidateData(){
            if( this.Username.Length > 0 && this.Firstname.Length > 0 && this.Lastname.Length > 0 ){
                return true;
            }
            return false;
        }

    }

}