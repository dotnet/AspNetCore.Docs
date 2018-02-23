using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HttpClientFactorySample
{
    public class ValuesService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ValuesService> _logger;

        public ValuesService() { }

        public ValuesService(HttpClient client, IMemoryCache cache, ILogger<ValuesService> logger)
        {
            _httpClient = client;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<string>> GetValues()
        {
            var result = await _httpClient.GetAsync("api/values");
            var resultObj = Enumerable.Empty<string>();

            if (result.IsSuccessStatusCode)
            {
                resultObj = JsonConvert.DeserializeObject<IEnumerable<string>>(await result.Content.ReadAsStringAsync());
                _cache.Set("GetValue", resultObj);
            }
            else
            {
                if (_cache.TryGetValue("GetValue", out resultObj))
                {
                    _logger.LogWarning("Returning cached values as the values service is unavailable.");
                    return resultObj;
                }
                result.EnsureSuccessStatusCode();
            }
            return resultObj;
        }
    }
}