using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace CachingMemorySample.Snippets.Pages
{
    public class MyMemoryCacheModel : PageModel
    {
        private readonly MemoryCache _memoryCache;

        public MyMemoryCacheModel(MyMemoryCache myMemoryCache) =>
            _memoryCache = myMemoryCache.Cache;

        public void OnGetCacheSizeSetSize()
        {
            #region snippet_OnGetCacheSizeSetSize
            if (!_memoryCache.TryGetValue(CacheKeys.Entry, out DateTime cacheValue))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(1);

                // cacheEntryOptions.Size = 1;

                _memoryCache.Set(CacheKeys.Entry, cacheValue, cacheEntryOptions);
            }
            #endregion
        }

        public void OnGetCacheCompact()
        {
            #region snippet_OnGetCacheCompact
            _memoryCache.Remove(CacheKeys.Entry);
            _memoryCache.Compact(.25);
            #endregion
        }
    }
}
