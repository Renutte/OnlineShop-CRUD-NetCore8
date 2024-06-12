using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineShop.Models;
using OnlineShop.Web.Models;

namespace OnlineShop.Controllers
{
    public class StoresController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public StoresController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        // GET: Stores
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("api/Stores");

            if (response.IsSuccessStatusCode)
            {
                var stores = await response.Content.ReadFromJsonAsync<List<Store>>();
                return View(stores);
            }
            else
            {
                return View(new List<Store>());
            }
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/Stores/{id}");

            if (response.IsSuccessStatusCode)
            {
                var store = await response.Content.ReadFromJsonAsync<Store>();
                if (store == null)
                {
                    return NotFound();
                }
                return View(store);
            }

            return NotFound();
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Location,Name")] Store store)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ApiClient");
                var response = await client.PostAsJsonAsync("api/Stores", store);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(store);
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/Stores/{id}");

            if (response.IsSuccessStatusCode)
            {
                var store = await response.Content.ReadFromJsonAsync<Store>();
                if (store == null)
                {
                    return NotFound();
                }
                return View(store);
            }

            return NotFound();
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Location,Name")] Store store)
        {
            if (id != store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ApiClient");
                var response = await client.PutAsJsonAsync($"api/Stores/{id}", store);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/Stores/{id}");

            if (response.IsSuccessStatusCode)
            {
                var store = await response.Content.ReadFromJsonAsync<Store>();
                if (store == null)
                {
                    return NotFound();
                }
                return View(store);
            }

            return NotFound();
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.DeleteAsync($"api/Stores/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
