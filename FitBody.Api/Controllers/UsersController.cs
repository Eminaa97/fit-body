using FitBody.Common.Requests;
using FitBody.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        protected IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] UserSearchRequest request)
        {
            return Ok(_userService.Get(request));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        /// <summary>
        /// Get your own followers
        /// </summary>
        /// <returns></returns>
        [HttpGet("followers")]
        public IActionResult GetFollowers()
        {
            var userId = User.GetUserId();
            return Ok(_userService.GetFollowers(userId));
        }

        /// <summary>
        /// Get followers for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("followers/{userId}")]
        [AllowAnonymous]
        public IActionResult GetFollowersForUser(int userId)
        {
            return Ok(_userService.GetFollowers(userId));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(UserInsertRequest user)
        {
            return Ok(_userService.Insert(user));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdateRequest request)
        {
            return Ok(_userService.Update(id, request));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginRequest request)
        {
            try
            {
                return Ok(_userService.Login(request));
            }
            catch
            {
                return BadRequest("Invalid username or password");
            }
        }

        [HttpPost("follow/{userId}")]
        public IActionResult Follow(int userId)
        {
            return Ok(_userService.Follow(User.GetUserId(), userId));
        }

        [HttpPost("changeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _userService.ChangeStatus(id);
            return Ok(true);
        }

        [HttpPost("changePermission/{id}")]
        public IActionResult ChangePermission(int id)
        {
            _userService.ChangePermission(id);
            return Ok(true);
        }
    }
}