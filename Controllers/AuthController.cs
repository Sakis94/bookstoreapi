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
using bookstoreapi.Models;
using System.IdentityModel.Tokens.Jwt;

namespace bookstoreAPI.Controllers
{

    [AllowAnonymous]
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
        public IActionResult GetAction()
        {
            return Ok("TEST");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _userService.Login(input);
                    if (result == null)
                    {
                        return BadRequest("Sfalma");
                    }
                    else
                    {
                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(result) });
                    }

                }
                else
                {
                    return BadRequest("Sfalma");
                }

            }
            catch (Exception)
            {
                return BadRequest("Sfalma");
            }
        }

        [HttpPut("register")]
        public IActionResult Register([FromBody] User input)
        {
            try
            {
                var result = _userService.Register(input);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Sfalma");
            }
        }

    }
}