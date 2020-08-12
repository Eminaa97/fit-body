using FitBody.Api.Attributes;
using FitBody.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        public ReportsController(IUserService userService, IPostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        [HttpGet("users")]
        [ExcelTemplate("UsersTemplate.xslt")]
        public IActionResult GetUsersReport()
        {
            return Ok(_userService.GetMostFollowed());
        }

        [HttpGet("posts")]
        [ExcelTemplate("PostsTemplate.xslt")]
        public IActionResult GetPostsReport()
        {
            return Ok(_postService.GetMostLikedPosts());
        }
    }
}
