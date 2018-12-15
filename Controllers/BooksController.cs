using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Linq;
using System.Security.Claims;

namespace bookstoreapi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DBService _dbService;
        private readonly UserService _userService;
        public BooksController(DBService dbService, UserService userService)
        {

            _dbService = dbService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAction()
        {
			return Ok( HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role) );
        }
    }
}