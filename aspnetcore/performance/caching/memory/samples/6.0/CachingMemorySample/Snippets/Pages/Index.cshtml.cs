using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace CachingMemorySample.Snippets.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;

        public IndexModel(IMemoryCache memoryCache) =>
            _memoryCache = memoryCache;

        public void OnGetCacheRelative()
        {
            #region snippet_OnGetCacheRelative
            _memoryCache.Set(CacheKeys.Entry, DateTime.Now, TimeSpan.FromDays(1));
            #endregion
        }

        #region snippet_OnGetCacheGetOrCreate
        public void OnGetCacheGetOrCreate()
        {
            var cachedValue = _memoryCache.GetOrCreate(
                CacheKeys.Entry,
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(3);
                    return DateTime.Now;
                });

            // ...
        }

        public async Task OnGetCacheGetOrCreateAsync()
        {
            var cachedValue = await _memoryCache.GetOrCreateAsync(
                CacheKeys.Entry,
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(3);
                    return Task.FromResult(DateTime.Now);
                });

            // ...
        }
        #endregion

        public void OnGetCacheGet()
        {
            #region snippet_OnGetCacheGet
            var cacheEntry = _memoryCache.Get<DateTime?>(CacheKeys.Entry);
            #endregion
        }

        public void OnGetCacheGetOrCreateAbsolute()
        {
            #region snippet_OnGetCacheGetOrCreateAbsolute
            var cachedValue = _memoryCache.GetOrCreate(
                CacheKeys.Entry,
                cacheEntry =>
                {
                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
                    return DateTime.Now;
                });
            #endregion
        }

        public void OnGetCacheGetOrCreateSlidingAbsolute()
        {
            #region snippet_OnGetCacheGetOrCreateSlidingAbsolute
            var cachedValue = _memoryCache.GetOrCreate(
                CacheKeys.CallbackEntry,
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(3);
                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
                    return DateTime.Now;
                });
            #endregion
        }

        #region snippet_MemoryCacheEntryOptions
        public void OnGetCacheRegisterPostEvictionCallback()
        {
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                .SetPriority(CacheItemPriority.NeverRemove)
                .RegisterPostEvictionCallback(PostEvictionCallback, _memoryCache);

            _memoryCache.Set(CacheKeys.CallbackEntry, DateTime.Now, memoryCacheEntryOptions);
        }

        private static void PostEvictionCallback(
            object cacheKey, object cacheValue, EvictionReason evictionReason, object state)
        {
            var memoryCache = (IMemoryCache)state;

            memoryCache.Set(
                CacheKeys.CallbackMessage,
                $"Entry {cacheKey} was evicted: {evictionReason}.");
        }
        #endregion

        #region snippet_CacheDependencies
        public void OnGetCacheCreateDependent()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            _memoryCache.Set(
                CacheKeys.DependentCancellationTokenSource,
                cancellationTokenSource);

            using var parentCacheEntry = _memoryCache.CreateEntry(CacheKeys.Parent);

            parentCacheEntry.Value = DateTime.Now;

            _memoryCache.Set(
                CacheKeys.Child,
                DateTime.Now,
                new CancellationChangeToken(cancellationTokenSource.Token));
        }

        public void OnGetCacheRemoveDependent()
        {
            var cancellationTokenSource = _memoryCache.Get<CancellationTokenSource>(
                CacheKeys.DependentCancellationTokenSource);

            cancellationTokenSource.Cancel();
        }
        #endregion

        public void OnGeCacheExpirationToken()
        {
            #region snippet_OnGeCacheExpirationToken
            if (!_memoryCache.TryGetValue(CacheKeys.Entry, out DateTime cacheValue))
            {
                cacheValue = DateTime.Now;

                var cancellationTokenSource = new CancellationTokenSource(
                    TimeSpan.FromSeconds(10));

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .AddExpirationToken(
                        new CancellationChangeToken(cancellationTokenSource.Token));

                _memoryCache.Set(CacheKeys.Entry, cacheValue, cacheEntryOptions);
            }
            #endregion
        }
    }
}
