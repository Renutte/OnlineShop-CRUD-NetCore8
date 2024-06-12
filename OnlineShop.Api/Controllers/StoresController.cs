using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services;
using OnlineShop.Api.Dtos;
using System.Collections.Generic;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/stores")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StoreDto>> GetStores()
        {
            var stores = _storeService.GetAllStores();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public ActionResult<StoreDto> GetStore(int id)
        {
            var store = _storeService.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        public IActionResult CreateStore(StoreDto storeDto)
        {
            _storeService.CreateStore(storeDto);
            return CreatedAtAction(nameof(GetStore), new { id = storeDto.Id }, storeDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStore(int id, StoreDto storeDto)
        {
            _storeService.UpdateStore(id, storeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            _storeService.DeleteStore(id);
            return NoContent();
        }
    }
}
