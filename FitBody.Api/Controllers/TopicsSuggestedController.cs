using FitBody.Common.Contracts;
using FitBody.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsSuggestedController : ControllerBase
    {
        protected ITopicSuggestedService _topicSuggestedService;

        public TopicsSuggestedController(ITopicSuggestedService topicSuggestedService)
        {
            _topicSuggestedService = topicSuggestedService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_topicSuggestedService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_topicSuggestedService.Get(id));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            return Ok(_topicSuggestedService.SuggestedTopicsForUser(userId));
        }

        [HttpPost]
        public IActionResult Insert(TopicSuggestedInsertModel topicSuggested)
        {
            return Ok(_topicSuggestedService.Insert(topicSuggested));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _topicSuggestedService.Delete(id);
            return Ok();
        }
    }
}