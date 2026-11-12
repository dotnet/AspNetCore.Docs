using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace CachingMemorySample.Snippets.Pages;

public class MyMemoryCacheModel : PageModel
{
    private readonly MyMemoryCache _myMemoryCache;

    public MyMemoryCacheModel(MyMemoryCache myMemoryCache) =>
        _myMemoryCache = myMemoryCache;

    public void OnGetCacheSizeSetSize()
    {
        // <snippet_OnGetCacheSizeSetSize>
        if (!_myMemoryCache.Cache.TryGetValue(CacheKeys.Entry, out DateTime cacheValue))
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSize(1);

            // cacheEntryOptions.Size = 1;

            _myMemoryCache.Cache.Set(CacheKeys.Entry, cacheValue, cacheEntryOptions);
        }
        // </snippet_OnGetCacheSizeSetSize>
    }

    public void OnGetCacheCompact()
    {
        // <snippet_OnGetCacheCompact>
        _myMemoryCache.Cache.Remove(CacheKeys.Entry);
        _myMemoryCache.Cache.Compact(.25);
        // </snippet_OnGetCacheCompact>
    }
}
