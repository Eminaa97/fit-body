using FitBody.Common.Contracts;
using FitBody.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        protected ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tagService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_tagService.Get(id));
        }

        [HttpGet("posts/{id}")]
        public IActionResult GetByPost(int id)
        {
            return Ok(_tagService.GetPerPost(id));
        }

        [HttpPost("search")]
        public IActionResult Get([FromBody] TagSearchRequest request)
        {
            return Ok(_tagService.Get(request));
        }

        [HttpPost]
        public IActionResult Insert(TagInsertModel tagModel)
        {
            var exists = _tagService.Get(new TagSearchRequest
            {
                Title = tagModel.Title
            }).FirstOrDefault();

            if (exists == null)
            {
                _tagService.Insert(tagModel);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tagService.Delete(id);
            return Ok();
        }
    }
}