using FitBody.Common.Contracts;
using FitBody.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        protected ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService )
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_categoryService.Get(id));
        }
        [HttpPost("search")]
        public IActionResult Get([FromBody] CategorySearchRequest request)
        {
            return Ok(_categoryService.Get(request));
        }

        [HttpPost]
        public IActionResult Insert(CategoryInsertModel category)
        {
            return Ok(_categoryService.Insert(category));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}