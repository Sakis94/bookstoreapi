using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Models;
using Services;

namespace bookstoreAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly DBService _dbService;
        private readonly UserService _userService;

        public AuthController(DBService dbService, UserService userService)
        {
            _dbService = dbService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAction(){
            return Ok("TEST");
        }
        
        /* Login */
        [HttpPost("login")]
        // [Authorize(Roles = "Administrators")]
        public IActionResult Post([FromBody] User inputuUser){

			var userResponse = new UserResponse();
			var dbUser = _userService.GetUserByUsername( inputuUser.Username );
			var perform = _userService.Login( inputuUser.Password, dbUser.Password );

			if( perform ){
				userResponse.ErrorLevel = UserResponse.ERROR_SUCCESS;
				userResponse.UserData = dbUser;
			}

			return Ok( userResponse );
        }

        /* Logout */
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] User user){
            //_userService.LogoutUser( user.Id );
            return Ok();
        }

        /* Register */
		[AllowAnonymous]
        [HttpPut("register")]
        public IActionResult Create([FromBody] User user)
        {
            var collection = new Dictionary<string, object>();

            if( user.ValidateData() ){
                _userService.CreateUser( user );
                collection.Add("errorLevel", 0);
                collection.Add("errorMessage", "Account created successfully!");
                return Ok(collection);
            } else {
                collection.Add("errorLevel", 1);
                collection.Add("errorMessage", "User data is invalid");
            }

            return Ok(collection);
        }

    }
}