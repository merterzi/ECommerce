using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync(false);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var product = await _productService.GetProductByIdAsync(id, false);
            return Ok(product);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtoForInsertion productDto)
        {
            var product = await _productService.AddProductAsync(productDto);
            return StatusCode(201, product);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute(Name = "id")] int id)
        {
            await _productService.DeleteProductAsync(id, false);
            return NoContent();
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productDto)
        {
            await _productService.UpdateProductAsync(id, productDto, false);
            return NoContent();
        }
    }
}
