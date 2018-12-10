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

using Dtos;
using Models;
using Services;
using Auth;

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

        /* Logout */
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] User user){
            //_userService.LogoutUser( user.Id );
            return Ok();
        }

		/* Login */
		[AllowAnonymous]
		[HttpPost("login")]
        // [Authorize(Roles = "Administrators")]
        public IActionResult Login([FromBody] UserDTO input){
			var result = _userService.Register(input);
			if( result ){
				return Ok( result );
			} else {
				return BadRequest();
			}
		}

		/* Register */
		[AllowAnonymous]
		[Auth(Optional = true)]
		[HttpPut("register")]
		public IActionResult Register([FromBody] UserDTO input){
			var result = _userService.Register(input);
			if( result ){
				return Ok();
			} else {
				return BadRequest();
			}
		}

    }
}