using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using RPcache.Services;
using System;

namespace RPcache.Pages
{
    // <snippet>
    public class SetSize : PageModel
    {
        private MemoryCache _cache;
        public static readonly string MyKey = "_MyKey";

        public SetSize(MyMemoryCache memoryCache)
        {
            _cache = memoryCache.Cache;
        }

        [TempData]
        public string DateTime_Now { get; set; }

        // <snippet2>
        public IActionResult OnGet()
        {
            if (!_cache.TryGetValue(MyKey, out string cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now.TimeOfDay.ToString();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Set cache entry size by extension method.
                    .SetSize(1)
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                // Set cache entry size via property.
                // cacheEntryOptions.Size = 1;

                // Save data in cache.
                _cache.Set(MyKey, cacheEntry, cacheEntryOptions);
            }

            DateTime_Now = cacheEntry;

            return RedirectToPage("./Index");
        }
        // </snippet2>
    }
    // </snippet>
}
