using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestorDeMembresia.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7204/");
            _httpClient = httpClient;
        }

        // 🔹 POST: api/Membresias/agregar
        public async Task<bool> AgregarMembresiaAsync(MembresiaDto membresia)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/Membresias/agregar")
            {
                Content = JsonContent.Create(membresia)
            };
            request.Headers.Add("apiKey", "1234");

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        // 🔹 GET: api/Membresias/listar
        public async Task<List<MembresiaDto>> GetMembresiasRegistradasAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Membresias/listar");
            request.Headers.Add("apiKey", "TU_API_KEY");

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<MembresiaDto>>() ?? new List<MembresiaDto>();

            return new List<MembresiaDto>();
        }

        // 🔹 GET: api/Membresias/vencidas
        public async Task<List<MembresiaDto>> GetMembresiasVencidasAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Membresias/vencidas");
            request.Headers.Add("apiKey", "TU_API_KEY");

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<MembresiaDto>>() ?? new List<MembresiaDto>();

            return new List<MembresiaDto>();
        }

        // 🔹 GET: api/Membresias/activas
        public async Task<List<MembresiaDto>> GetMembresiasActivasAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Membresias/activas");
            request.Headers.Add("apiKey", "TU_API_KEY");

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<MembresiaDto>>() ?? new List<MembresiaDto>();

            return new List<MembresiaDto>();
        }

        // 🔹 GET: api/Membresias/{id}
        public async Task<MembresiaDto?> GetMembresiaPorIdAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Membresias/{id}");
            request.Headers.Add("apiKey", "TU_API_KEY");

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<MembresiaDto>();

            return null;
        }

        // 🔹 GET: api/Membresias/test-db
        public async Task<string> TestDatabaseAsync()
        {
            var response = await _httpClient.GetAsync("api/Membresias/test-db");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return "❌ Error al conectar con la base de datos.";
        }
    }
}
