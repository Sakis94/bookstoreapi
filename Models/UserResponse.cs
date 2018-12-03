using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
	public class UserResponse {

		public static int ERROR_SUCCESS  = 0;
		public static int ERROR_USERNAME = 1;
		public static int ERROR_PASSWORD = 2;

		public static string ERROR_MSG_USERNAME = "This username is not exists";
		public static string ERROR_MSG_PASSWORD = "Wrong password for this user";

		public int ErrorLevel;
		public string ErrorMessage;
		public User UserData;

	}
}
