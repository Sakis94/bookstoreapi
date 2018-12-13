using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Auth
{
	public class AuthorizeUserAccessLevel : AuthorizeAttribute {

		protected override bool AuthorizeCore(HttpContextBase httpContext){
		}
		
	}
}
