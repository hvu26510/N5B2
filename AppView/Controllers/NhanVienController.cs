using AppView.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NhanVienController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient ApiClient() => _httpClientFactory.CreateClient("api");

        // GET: NhanVienController
        public async Task<IActionResult> Index()
        {
            var client = ApiClient();

            var data = await client.GetFromJsonAsync<List<NhanVienViewModel>>("api/NhanViens");

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NhanVienViewModel nv)
        {
            if(!ModelState.IsValid) return View(nv);

            var client = ApiClient();

            var response = await client.PostAsJsonAsync("api/NhanViens", nv);

            if (!response.IsSuccessStatusCode) {
                var err = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", "That bai" + err);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var client = ApiClient();
            //api/NhanViens/{id}
            var nvVM = await client.GetFromJsonAsync<NhanVienViewModel>($"api/NhanViens/{id}");

            return View(nvVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, NhanVienViewModel nv)
        {
            if (!ModelState.IsValid) return View(nv);

            var client = ApiClient();

            var response = await client.PutAsJsonAsync($"api/NhanViens/{id}", nv);
            if (!response.IsSuccessStatusCode)
            {
                var err = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", "That bai" + err);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var client = ApiClient();
            //api/NhanViens/{id}
            await client.DeleteAsync($"api/NhanViens/{id}");

            return RedirectToAction(nameof(Index));
        }

    }
}
