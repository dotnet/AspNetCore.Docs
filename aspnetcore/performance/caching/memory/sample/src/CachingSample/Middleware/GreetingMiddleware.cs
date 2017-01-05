using System;
using System.Threading.Tasks;
using CachingSample.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CachingSample
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GreetingMiddleware
    {
        private readonly IGreetingService _greetingService;
        private readonly ILogger<GreetingMiddleware> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly RequestDelegate _next;

        public GreetingMiddleware(RequestDelegate next,
            IMemoryCache memoryCache,
            ILogger<GreetingMiddleware> logger,
            IGreetingService greetingService)
        {
            _next = next;
            _memoryCache = memoryCache;
            _greetingService = greetingService;
            _logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string cacheKey = "GreetingMiddleware-Invoke";
            string greeting;

            // try to get the cached item; null if not found
            // greeting = _memoryCache.Get(cacheKey) as string;

            // alternately, TryGet returns true if the cache entry was found
            if(!_memoryCache.TryGetValue(cacheKey, out greeting))
            {
                // fetch the value from the source
                greeting = _greetingService.Greet("world");

                // store in the cache
                _memoryCache.Set(cacheKey, greeting,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
                _logger.LogInformation($"{cacheKey} updated from source.");
            }
            else
            {
                _logger.LogInformation($"{cacheKey} retrieved from cache.");
            }

            return httpContext.Response.WriteAsync(greeting);
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GreetingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGreetingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GreetingMiddleware>();
        }
    }
}
