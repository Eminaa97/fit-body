using FitBody.Common.Contracts;
using FitBody.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        protected ISubcategoryService _subcategoryService;

        public SubcategoriesController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_subcategoryService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_subcategoryService.Get(id));
        }

        [HttpPost]
        public IActionResult Insert(SubcategoryInsertModel category)
        {
            _subcategoryService.Insert(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subcategoryService.Delete(id);
            return Ok();
        }
    }
}