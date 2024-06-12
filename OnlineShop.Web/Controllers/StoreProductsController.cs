using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using OnlineShop.Models;
using OnlineShop.Web.Models;

namespace OnlineShop.Controllers
{
    public class StoreProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public StoreProductsController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        // GET: StoreProducts
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("api/StoreProducts");

            if (response.IsSuccessStatusCode)
            {
                var storeProducts = await response.Content.ReadFromJsonAsync<List<StoreProduct>>();
                return View(storeProducts);
            }
            else
            {
                return View(new List<StoreProduct>());
            }
        }

        // GET: StoreProducts/Details/5
        public async Task<IActionResult> Details(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/StoreProducts/{storeId}/{productId}");

            if (response.IsSuccessStatusCode)
            {
                var storeProduct = await response.Content.ReadFromJsonAsync<StoreProduct>();
                if (storeProduct == null)
                {
                    return NotFound();
                }
                return View(storeProduct);
            }

            return NotFound();
        }

        // GET: StoreProducts/Create
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var productsResponse = await client.GetAsync("api/Products");
            var storesResponse = await client.GetAsync("api/Stores");

            if (productsResponse.IsSuccessStatusCode && storesResponse.IsSuccessStatusCode)
            {
                var products = await productsResponse.Content.ReadFromJsonAsync<List<Product>>();
                var stores = await storesResponse.Content.ReadFromJsonAsync<List<Store>>();

                ViewData["ProductId"] = new SelectList(products, "Id", "Id");
                ViewData["StoreId"] = new SelectList(stores, "Id", "Id");
            }
            return View();
        }

        // POST: StoreProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,ProductId,Stock")] StoreProduct storeProduct)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.PostAsJsonAsync("api/storeproducts", storeProduct);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = $"Error: {errorContent}";
                return RedirectToAction(nameof(Create));
            }
            else
            {
                var productsResponse = await client.GetAsync("api/Products");
                var storesResponse = await client.GetAsync("api/Stores");

                if (productsResponse.IsSuccessStatusCode && storesResponse.IsSuccessStatusCode)
                {
                    var products = await productsResponse.Content.ReadFromJsonAsync<List<Product>>();
                    var stores = await storesResponse.Content.ReadFromJsonAsync<List<Store>>();

                    ViewData["ProductId"] = new SelectList(products, "Id", "Id", storeProduct.ProductId);
                    ViewData["StoreId"] = new SelectList(stores, "Id", "Id", storeProduct.StoreId);
                }
                return View(storeProduct);
            }
        }




        // GET: StoreProducts/Edit/5
        public async Task<IActionResult> Edit(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/StoreProducts/{storeId}/{productId}");

            if (response.IsSuccessStatusCode)
            {
                var storeProduct = await response.Content.ReadFromJsonAsync<StoreProduct>();
                if (storeProduct == null)
                {
                    return NotFound();
                }

                var productsResponse = await client.GetAsync("api/Products");
                var storesResponse = await client.GetAsync("api/Stores");

                if (productsResponse.IsSuccessStatusCode && storesResponse.IsSuccessStatusCode)
                {
                    var products = await productsResponse.Content.ReadFromJsonAsync<List<Product>>();
                    var stores = await storesResponse.Content.ReadFromJsonAsync<List<Store>>();

                    ViewData["ProductId"] = new SelectList(products, "Id", "Id", storeProduct.ProductId);
                    ViewData["StoreId"] = new SelectList(stores, "Id", "Id", storeProduct.StoreId);
                }
                return View(storeProduct);
            }

            return NotFound();
        }

        // POST: StoreProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int storeId, int productId, [Bind("StoreId,ProductId,Stock")] StoreProduct storeProduct)
        {
            if (storeId != storeProduct.StoreId || productId != storeProduct.ProductId)
            {
                return BadRequest();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PutAsJsonAsync($"api/StoreProducts/{storeId}/{productId}", storeProduct);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var productsResponse = await client.GetAsync("api/Products");
                var storesResponse = await client.GetAsync("api/Stores");

                if (productsResponse.IsSuccessStatusCode && storesResponse.IsSuccessStatusCode)
                {
                    var products = await productsResponse.Content.ReadFromJsonAsync<List<Product>>();
                    var stores = await storesResponse.Content.ReadFromJsonAsync<List<Store>>();

                    ViewData["ProductId"] = new SelectList(products, "Id", "Id", storeProduct.ProductId);
                    ViewData["StoreId"] = new SelectList(stores, "Id", "Id", storeProduct.StoreId);
                }
                return View(storeProduct);
            }
        }

        // GET: StoreProducts/Delete/5
        public async Task<IActionResult> Delete(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/StoreProducts/{storeId}/{productId}");

            if (response.IsSuccessStatusCode)
            {
                var storeProduct = await response.Content.ReadFromJsonAsync<StoreProduct>();
                if (storeProduct == null)
                {
                    return NotFound();
                }
                return View(storeProduct);
            }

            return NotFound();
        }

        // POST: StoreProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int storeId, int productId)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.DeleteAsync($"api/StoreProducts/{storeId}/{productId}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
