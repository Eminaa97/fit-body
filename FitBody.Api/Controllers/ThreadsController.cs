using FitBody.Common.Contracts;
using FitBody.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ThreadsController : ControllerBase
    {
        protected IThreadService _threadService;

        public ThreadsController(IThreadService threadService)
        {
            _threadService = threadService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_threadService.Get());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_threadService.Get(id));
        }

        [HttpPost("search")]
        [AllowAnonymous]
        public IActionResult Get([FromBody] ThreadSearchRequest request)
        {
            return Ok(_threadService.Get(request));
        }

        [HttpPost]
        public IActionResult Insert(ThreadInsertModel thread)
        {
            thread.UserId = User.GetUserId();
            return Ok(_threadService.Insert(thread));
        }

        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            _threadService.Delete(id);
            return Ok();
        }
    }
}