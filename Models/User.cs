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

        public void CalculatePassword(){
            var input = this.Password;
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++){
                sb.Append(hash[i].ToString("X2"));
            }

            this.Password = sb.ToString();
        }

    }

}