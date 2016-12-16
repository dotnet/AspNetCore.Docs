using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

#region snippet_ctor
public class HomeController : Controller
{   
    private IMemoryCache _memoryCache;

    public HomeController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    #endregion

    #region snippet1
    public IActionResult Index()
    {
        DateTime cachedVal;

        // Look for cache key.
        if (!_memoryCache.TryGetValue(CacheKey.Time, out cachedVal))
        {
            // Key not in cache, so get data.
            cachedVal = DateTime.Now;

            // Set cache options.
            var cacheOptions = new MemoryCacheEntryOptions()
            {
                // Cache a short time for easy testing.
                SlidingExpiration = TimeSpan.FromSeconds(3),
            };

            // Save data in cache.
            _memoryCache.Set(CacheKey.Time, cachedVal, cacheOptions);
        }

        return View(cachedVal);
    }
    #endregion

    #region snippet_gct
    public IActionResult GetCachedTime()
    {
        var cachedVal = _memoryCache.Get<DateTime>(CacheKey.Time);
        return View("Index", cachedVal);
    }
    #endregion

    #region snippet2
    public IActionResult Index2()
    {
        DateTime cachedVal = _memoryCache.GetOrCreate<DateTime>(CacheKey.Time, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(3);
            return DateTime.Now;
        });

        return View("Index", cachedVal);
    }

    public async Task<IActionResult> Index3()
    {
        DateTime cachedVal = await
            _memoryCache.GetOrCreateAsync<DateTime>(CacheKey.Time, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(3);
            return Task.FromResult<DateTime>(DateTime.Now);
        });

        return View("Index", cachedVal);
    }
    #endregion

    public IActionResult Remove()
    {
        _memoryCache.Remove(CacheKey.Time);

        return View("Index");
    }

    #region snippet_et
    public IActionResult EvictionTime()
    {
        _memoryCache.Set<DateTime>(CacheKey.MS,
            DateTime.Now,
            GetMemCacheOptions(6, 2, CacheItemPriority.NeverRemove, AfterEvicted));

        // Don't use previous message.
        _memoryCache.Remove(CacheKey.EvictMsg1);

        return RedirectToAction("CheckEvictionTime");
    }

    private MemoryCacheEntryOptions GetMemCacheOptions(int absExpire, int slideExpire,
      CacheItemPriority cachePriority, PostEvictionDelegate postEvictDelegate)
    {
        return new MemoryCacheEntryOptions()
            // Longest possible time to keep in cache.
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(absExpire))
            // Keep in cache for this time, reset time if accessed.
            .SetSlidingExpiration(TimeSpan.FromSeconds(slideExpire))
            // Pin to cache.
            .SetPriority(cachePriority)
            .RegisterPostEvictionCallback(postEvictDelegate, state: this);
    }

    // Show key value and why key was evicted.
    private static void AfterEvicted(object key, object value,
        EvictionReason reason, object state)
    {
        var em = $"key: {key}, Value: {value}, Reason: {reason}";
        ((HomeController)state)._memoryCache.Set<string>(CacheKey.EvictMsg1, em);
    }

    public IActionResult CheckEvictionTime()
    {
        ViewData["Message"] = _memoryCache.Get<string>(CacheKey.EvictMsg1);

        return View(_memoryCache.Get<DateTime>(CacheKey.MS));
    }
    #endregion


    #region snippet_ed
    public IActionResult EvictDependency()
    {
        // Clear out eviction message, and key from previous run (if any).
        _memoryCache.Remove(CacheKey.EvictMsg2);
        CancellationTokenSource cts2 = new CancellationTokenSource();
        _memoryCache.Set<CancellationTokenSource>(CacheKey.CancelTokenSource2, cts2);

        using (var entry = _memoryCache.CreateEntry(CacheKey.MS2))
        {
            // expire this entry if the dependant entry expires.
            entry.Value = DateTime.Now.TimeOfDay.Milliseconds.ToString();
            entry.RegisterPostEvictionCallback(AfterEvicted2, this);

            _memoryCache.Set(CacheKey.MS3,
                DateTime.Now.AddMilliseconds(4).TimeOfDay.Milliseconds.ToString(),
                new CancellationChangeToken(cts2.Token));
        }

        return RedirectToAction("CheckEvictDependency");
    }

    public IActionResult CheckEvictDependency(int? id)
    {
        ViewData["CachedMS2"] = _memoryCache.Get<string>(CacheKey.MS2);
        ViewData["CachedMS3"] = _memoryCache.Get<string>(CacheKey.MS3);
        ViewData["MessageCED"] = _memoryCache.Get<string>(CacheKey.EvictMsg2);

        if (id > 0)
        {
            CancellationTokenSource cts2 =
                _memoryCache.Get<CancellationTokenSource>(CacheKey.CancelTokenSource2);
            cts2.Cancel();
        }

        return View();
    }
    #endregion

    private static void AfterEvicted2(object key, object value,
                                      EvictionReason reason, object state)
    {
        var em = $"key: {key}, Value: {value}, Reason: {reason}";
        ((HomeController)state)._memoryCache.Set<string>(CacheKey.EvictMsg2, em);
    }
     

    public IActionResult CheckCancel(int? id = 0)
    {
        if (id > 0)
        {
            CancellationTokenSource cts =
               _memoryCache.Get<CancellationTokenSource>(CacheKey.CancelTokenSource);
            cts.CancelAfter(100);
            // Cancel immediately with cts.Cancel();
        }

        ViewData["CachedTime"] = _memoryCache.Get<string>(CacheKey.Ticks);
        ViewData["Message"] =  _memoryCache.Get<string>(CacheKey.CancelMsg); ;

        return View();
    }
    public IActionResult CancelTest()
    {
        var cachedVal = DateTime.Now.Second.ToString();
        CancellationTokenSource cts = new CancellationTokenSource();
        _memoryCache.Set<CancellationTokenSource>(CacheKey.CancelTokenSource, cts);

        // Don't use previous message.
        _memoryCache.Remove(CacheKey.CancelMsg);

        _memoryCache.Set(CacheKey.Ticks, cachedVal,
            new MemoryCacheEntryOptions()
            .AddExpirationToken(new CancellationChangeToken(cts.Token))
            .RegisterPostEvictionCallback(
                (key, value, reason, substate) =>
                {
                    var cm = $"'{key}':'{value}' was evicted because: {reason}"; 
                    _memoryCache.Set<string>(CacheKey.CancelMsg, cm);
                }
            ));

        return RedirectToAction("CheckCancel");
    }
}

