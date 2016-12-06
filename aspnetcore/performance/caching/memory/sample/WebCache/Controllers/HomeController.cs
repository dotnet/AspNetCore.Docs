using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using Microsoft.Extensions.Primitives;

public class HomeController : Controller
{
    private const string CacheKeyTime = "_CacheKeyTime";
    private const string CacheKeyMS = "_CacheKeyMS";
    private const string CacheKeyMS2 = "_CacheKeyMS2";
    private const string CacheKeyMS3 = "_CacheKeyMS3";
    private const string CacheKeyTicks = "_CacheKeyTicks";
    private IMemoryCache _memoryCache;
    private static string _evictionMsg1;
    private static string _evictionMsg2;
    private static string _cancellationMsg;
    private static CancellationTokenSource _cts = new CancellationTokenSource();
    private static CancellationTokenSource _cts2 = new CancellationTokenSource();

    public HomeController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public IActionResult Index()
    {
        string cachedVal;

        // Look for cache key.
        if (!_memoryCache.TryGetValue(CacheKeyTime, out cachedVal))
        {
            // Key not in cache, so get data.
            cachedVal = DateTime.Now.TimeOfDay.ToString();

            // Set cache options.
            var cacheOptions = new MemoryCacheEntryOptions()
            {
                // Cache a short time for easy testing.
                SlidingExpiration = TimeSpan.FromSeconds(5),
                // Evict this under memory pressure before
                // normal (default) and high. 
                Priority = CacheItemPriority.Low
            };

            // Save data in cache.
            _memoryCache.Set(CacheKeyTime, cachedVal, cacheOptions);
        }

        ViewData["CachedTime"] = cachedVal;

        return View();
    }

    public string TestCopy()
    {
        var cacheEntry = _memoryCache.CreateEntry("key1");
        return "";

    }

    public IActionResult Remove()
    {
        _memoryCache.Remove(CacheKeyTime);
        ViewData["CachedTime"] = "Removed";

        return View("Index");
    }

    public IActionResult Get()
    {
        ViewData["CachedTime"] = _memoryCache.Get<string>(CacheKeyTime);
        return View("Index");
    }   

    public IActionResult EvictionTime()
    {
        _memoryCache.Set<string>(CacheKeyMS,
            DateTime.Now.TimeOfDay.Milliseconds.ToString(),
            GetMemCacheOptions(6, 2, CacheItemPriority.NeverRemove, AfterEvicted));

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
            .RegisterPostEvictionCallback(postEvictDelegate, state: null);
    }

    // Show key value and why key was evicted.
    private static void AfterEvicted(object key, object value,
        EvictionReason reason, object state)
    {
        _evictionMsg1 = "Value: " + value + ", Reason: " + reason;
    }

    public IActionResult CheckEvictionTime()
    {
        ViewData["CachedMS"] = _memoryCache.Get<string>(CacheKeyMS);
        ViewData["Message"] = _evictionMsg1;

        return View();
    }

    // Expire an entry if the dependent entry expires
    public IActionResult EvictDependency()
    {
        using (var entry = _memoryCache.CreateEntry(CacheKeyMS2))
        {
            // expire this entry if the entry with key "CacheKeyMS23" expires.
            entry.Value = DateTime.Now.TimeOfDay.Milliseconds.ToString();
            entry.RegisterPostEvictionCallback(AfterEvicted2);
            Thread.Sleep(5);
            _memoryCache.Set(CacheKeyMS3,
                DateTime.Now.TimeOfDay.Milliseconds.ToString(),
                new CancellationChangeToken(_cts2.Token));
        }

       return RedirectToAction("CheckEvictDependency");
    }

    public IActionResult CheckEvictDependency(int ? id)
    {
        ViewData["CachedMS2"] = _memoryCache.Get<string>(CacheKeyMS2);
        ViewData["CachedMS3"] = _memoryCache.Get<string>(CacheKeyMS3);
        ViewData["Message"] = _evictionMsg2;

        if (id > 0)
        {
            _cts2.Cancel();
        }
        return View();
    }

    private static void AfterEvicted2(object key, object value,
    EvictionReason reason, object state)
    {
        _evictionMsg2 = "Value: " + value + ", Reason: " + reason;
    }

    public IActionResult CheckCancel(int? id = 0)
    {
        if (id > 0)
        {
            _cts.CancelAfter(100);
            // Cancel immediately with _cts.Cancel();
        }

        ViewData["CachedTime"] = _memoryCache.Get<string>(CacheKeyTicks);
        ViewData["Message"] = _cancellationMsg;

        return View();
    }
    public IActionResult CancelTest()
    {
        var cachedVal = DateTime.Now.Second.ToString();

        _memoryCache.Set(CacheKeyTicks, cachedVal,
            new MemoryCacheEntryOptions()
            .AddExpirationToken(new CancellationChangeToken(_cts.Token))
            .RegisterPostEvictionCallback(
                (key, value, reason, substate) =>
                {
                    _cancellationMsg = $"'{key}':'{value}' was evicted because: {reason}";
                }
            ));

        return RedirectToAction("CheckCancel");
    }
}

