using AJMSnusbolaget.Models;
using System.Text.Json;

namespace AJMSnusbolaget.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://ajm-snus.azurewebsites.net";

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/snus");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch products.");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
