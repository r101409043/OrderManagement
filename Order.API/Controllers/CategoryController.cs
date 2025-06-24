using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var categories = await service.GetAllAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var category = await service.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpGet("GetCategoryByParentCategoryId")]
        public async Task<IActionResult> GetByParentId([FromQuery] int parentId)
        {
            var categories = await service.GetByParentCategoryIdAsync(parentId);
            return Ok(categories);
        }

        [HttpPost("SaveCategory")]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            var created = await service.CreateAsync(category);
            return Ok(created);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }
    }
}