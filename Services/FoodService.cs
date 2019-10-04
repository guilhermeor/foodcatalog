using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace FoodCatalog.Services
{
    public class FoodService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        public FoodService(HttpClient httpClient, IMemoryCache memoryCache) { _httpClient = httpClient; _memoryCache = memoryCache; }

        public async Task<IEnumerable<FoodRequest>> Get() => await _memoryCache.GetOrCreateAsync("foods", _ => { return GetData(); });

        private async Task<IEnumerable<FoodRequest>> GetData()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("food");
            var foods = await JsonSerializer.DeserializeAsync<IEnumerable<FoodRequest>>(await response.Content.ReadAsStreamAsync());
            _memoryCache.Set("foods", foods);
            return foods;
        }
    }
}
