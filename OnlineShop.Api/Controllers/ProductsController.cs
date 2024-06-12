using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services;
using OnlineShop.Api.Dtos;
using System.Collections.Generic;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            _productService.CreateProduct(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductDto productDto)
        {
            _productService.UpdateProduct(id, productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
