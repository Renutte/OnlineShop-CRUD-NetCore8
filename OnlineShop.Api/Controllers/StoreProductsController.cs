using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services;
using OnlineShop.Api.Dtos;
using System.Collections.Generic;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/storeproducts")]
    public class StoreProductsController : ControllerBase
    {
        private readonly IStoreProductService _storeProductService;

        public StoreProductsController(IStoreProductService storeProductService)
        {
            _storeProductService = storeProductService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StoreProductDto>> GetStoreProducts()
        {
            var storeProducts = _storeProductService.GetAllStoreProducts();
            return Ok(storeProducts);
        }

        [HttpGet("{storeId}/{productId}")]
        public ActionResult<StoreProductDto> GetStoreProduct(int storeId, int productId)
        {
            var storeProduct = _storeProductService.GetStoreProductById(storeId, productId);
            if (storeProduct == null)
            {
                return NotFound();
            }
            return Ok(storeProduct);
        }

        [HttpPost]
        public IActionResult PostStoreProduct(StoreProductDto storeProductDto)
        {
            if (_storeProductService.StoreProductExists(storeProductDto.StoreId, storeProductDto.ProductId))
            {
                return Conflict("Combination IDs already exist");
            }

            _storeProductService.CreateStoreProduct(storeProductDto);
            return CreatedAtAction(nameof(GetStoreProduct), new { storeId = storeProductDto.StoreId, productId = storeProductDto.ProductId }, storeProductDto);
        }

        [HttpPut("{storeId}/{productId}")]
        public IActionResult PutStoreProduct(int storeId, int productId, StoreProductDto storeProductDto)
        {
            if (_storeProductService.StoreProductExists(storeId, productId))
            {
                _storeProductService.UpdateStoreProduct(storeId, productId, storeProductDto);
                return NoContent();
            }
            else
            {
                return NotFound("Combination IDs does not exist.");
            }
        }

        [HttpDelete("{storeId}/{productId}")]
        public IActionResult DeleteStoreProduct(int storeId, int productId)
        {
            _storeProductService.DeleteStoreProduct(storeId, productId);
            return NoContent();
        }
    }
}
