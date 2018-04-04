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
        // todo - actually get something from github
        // todo - consume and expose via an API controller

        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _fallbackCache;
        private readonly ILogger<ValuesService> _logger;

        public ValuesService(HttpClient client, IMemoryCache cache, ILogger<ValuesService> logger)
        {
            _httpClient = client;
            _fallbackCache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<string>> GetValues()
        {
            var result = await _httpClient.GetAsync("api/values");

            List<string> resultObj;

            if (result.IsSuccessStatusCode)
            {
                resultObj = JsonConvert.DeserializeObject<IEnumerable<string>>(await result.Content.ReadAsStringAsync()).ToList();
                _fallbackCache.Set("GetValue", resultObj);
            }
            else
            {
                // try to fallback to a cached result
                if (_fallbackCache.TryGetValue("GetValue", out resultObj))
                {
                    _logger.LogWarning("Returning cached values as the values service is unavailable.");
                    return resultObj;
                }
                // if we reach here, then nothing is available in the cache so allow this to throw
                result.EnsureSuccessStatusCode();
            }

            return resultObj;
        }
    }
}