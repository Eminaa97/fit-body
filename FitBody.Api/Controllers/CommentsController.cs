using FitBody.Common.Contracts;
using FitBody.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        protected ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_commentService.Get());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_commentService.Get(id));
        }

        [HttpGet("posts/{postId}")]
        [AllowAnonymous]
        public IActionResult GetByPost(int postId)
        {
            return Ok(_commentService.GetByPost(postId));
        }

        [HttpGet("threads/{threadId}")]
        [AllowAnonymous]
        public IActionResult GetByThread(int threadId)
        {
            return Ok(_commentService.GetByThread(threadId));
        }

        [HttpPost]
        public IActionResult Insert(CommentInsertModel category)
        {
            category.UserId = User.GetUserId();
            return Ok(_commentService.Insert(category));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentService.Delete(id);
            return Ok();
        }
    }
}