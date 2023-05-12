using Entities.DTOs;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters productParameters)
        {
            var result = await _productService.GetAllProductsAsync(productParameters, false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.metaData));

            return Ok(result.products);
        }

        [Authorize]
        [HttpGet("details")]
        public async Task<IActionResult> GetAllProductsWithDetails()
        {
            return Ok(await _productService.GetAllProductsWithDetailsAsync(false));
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var product = await _productService.GetProductByIdAsync(id, false);
            return Ok(product);
        }

        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtoForInsertion productDto)
        {
            var product = await _productService.AddProductAsync(productDto);
            return StatusCode(201, product);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute(Name = "id")] int id)
        {
            await _productService.DeleteProductAsync(id, false);
            return NoContent();
        }

        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productDto)
        {
            await _productService.UpdateProductAsync(id, productDto, false);
            return NoContent();
        }
    }
}
