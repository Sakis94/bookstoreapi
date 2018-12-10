using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth
{
	// [AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public class AuthAttribute : Attribute {

		public bool optional = true;

		public AuthAttribute(){
			Console.WriteLine( "Optional: " + optional.ToString() );
		}

		public virtual bool Optional {
			get { return optional; } set { optional = value; }
		}

    }
}
