using FitBody.Api.Hubs;
using FitBody.Common.Contracts;
using FitBody.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly INotificationService _notificationService;

        public PostsController(
            IPostService postService,
            IHubContext<NotificationHub> hubContext,
            INotificationService notificationService
            )
        {
            _postService = postService;
            _hubContext = hubContext;
            _notificationService = notificationService;
        }

        [HttpGet("recommended")]
        public IActionResult GetRecommended()
        {
            var user = User.GetUserId();
            return Ok(_postService.GetRecommendedPosts(user));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_postService.Get());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_postService.Get(id));
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] PostSearchRequest request)
        {
            return Ok(_postService.Get(request));
        }

        /// <summary>
        /// Returns a list of posts with their like count
        /// </summary>
        /// <returns></returns>
        [HttpGet("mostliked")]
        public IActionResult GetPosts()
        {
            var userId = User.GetUserId();
            return Ok(_postService.GetLikedPosts(userId));
        }

        /// <summary>
        /// Retrieves a list of posts that this user has liked
        /// </summary>
        /// <returns></returns>
        [HttpGet("users/likes")]
        public IActionResult GetUsersLikedPosts()
        {
            var userId = User.GetUserId();
            return Ok(_postService.GetLikedPostsByUser(userId));
        }

        [HttpGet("users/saved")]
        public IActionResult GetUsersSavedPosts()
        {
            var userId = User.GetUserId();
            return Ok(_postService.GetSavedPostsByUser(userId));
        }

        [HttpPost]
        public IActionResult Insert(PostInsertModel post)
        {
            var user = User.GetUserId();
            post.UserId = user;

            var addedPost = _postService.Insert(post);

            var userFollowers = _notificationService.GetFollowers(post.UserId);

            _hubContext.Clients.All.SendAsync("ReceiveNotification", JsonConvert.SerializeObject(userFollowers), addedPost.Username).Wait();

            return Ok(addedPost);
        }

        [HttpPost("update")]
        public IActionResult Update(PostUpdateModel post)
        {
            _postService.Update(post);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] PostUpdateModel post)
        {
            _postService.Update(post);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postService.Delete(id);
            return Ok();
        }

        [HttpPost("like/{id}")]
        public IActionResult Like(int id)
        {
            return Ok(_postService.Like(id, User.GetUserId()));
        }

        [HttpPost("save/{id}")]
        public IActionResult Save(int id)
        {
            return Ok(_postService.Save(id, User.GetUserId()));
        }
        [HttpGet("followed")]
        public IActionResult GetPostsByFollowingUsers()
        {
            var user = User.GetUserId();
            return Ok(_postService.GetPostsByFollowingUsers(user));
        }
    }
}