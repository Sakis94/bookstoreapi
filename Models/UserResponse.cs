using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dtos;

namespace Models
{
	public class UserResponse {

		public static int ERROR_LOGIN_SUCCESS  = 0;
		public static int ERROR_LOGIN_USERNAME = 1;
		public static int ERROR_LOGIN_PASSWORD = 2;
		public static string ERROR_LOGIN_MSG_USERNAME = "This username is not exists";
		public static string ERROR_LOGIN_MSG_PASSWORD = "Wrong password for this user";

		public static int ERROR_REGISTER_SUCCESS = 3;
		public static int ERROR_REGISTER_ACCOUNT_EXISTS = 4;
		public static string ERROR_REGISTER_MSG_EXISTS = "This username is already taken";

		public int ErrorLevel;
		public string ErrorMessage;
		public UserDTO UserData;

	}
}
