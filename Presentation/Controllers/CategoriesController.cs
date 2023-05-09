using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync(false));
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAllCategoriesWithDetails()
        {
            return Ok(await _categoryService.GetAllCategoriesWithDetailsAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id, false);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            var category = await _categoryService.AddCategoryAsync(categoryDto);
            return StatusCode(201, category);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] int id)
        {
            await _categoryService.DeleteCategoryAsync(id, false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCatgeory([FromRoute(Name = "id")] int id, [FromBody] CategoryDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDto, false);
            return NoContent();
        }
    }
}
