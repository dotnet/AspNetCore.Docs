using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private const string CacheKeyTime = "_CacheKeyTime";
    private const string CacheKeyMS = "_CacheKeyMS";
    private const string CacheKeyMS2 = "_CacheKeyMS2";
    private const string CacheKeyMS3 = "_CacheKeyMS3";
    private const string CacheKeyTicks = "_CacheKeyTicks";
    private IMemoryCache _memoryCache;
    private static string _evictionMsg1;
    private string _evictionMsg2="not set";
    private static string _cancellationMsg;
    private static CancellationTokenSource _cts = new CancellationTokenSource();
    private static CancellationTokenSource _cts2 = new CancellationTokenSource();

    #region snippet_ctor
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
        if (!_memoryCache.TryGetValue(CacheKeyTime, out cachedVal))
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
            _memoryCache.Set(CacheKeyTime, cachedVal, cacheOptions);
        }

        return View(cachedVal);
    }
    #endregion

    #region snippet_gct
    public IActionResult GetCachedTime()
    {
        var cachedVal = _memoryCache.Get<DateTime>(CacheKeyTime);
        return View("Index", cachedVal);
    }
    #endregion

    #region snippet2
    public IActionResult Index2()
    {
        DateTime cachedVal = _memoryCache.GetOrCreate<DateTime>(CacheKeyTime, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(3);
            return DateTime.Now;
        });

        return View("Index", cachedVal);
    }

    public async Task<IActionResult> Index3()
    {
        DateTime cachedVal = await
            _memoryCache.GetOrCreateAsync<DateTime>(CacheKeyTime, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(3);
            return Task.FromResult<DateTime>(DateTime.Now);
        });

        return View("Index", cachedVal);
    }
    #endregion

    public IActionResult Remove()
    {
        _memoryCache.Remove(CacheKeyTime);

        ViewData["CachedTime"] = "Removed";

        return View("Index");
    }

    #region snippet_et
    public IActionResult EvictionTime()
    {
        _memoryCache.Set<DateTime>(CacheKeyMS,
            DateTime.Now,
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
        _evictionMsg1 = $"key: {key}, Value: {value}, Reason: {reason}";
    }

    public IActionResult CheckEvictionTime()
    {
        ViewData["Message"] = _evictionMsg1;

        return View(_memoryCache.Get<DateTime>(CacheKeyMS));
    }
    #endregion

    public IActionResult Index4()
    {
        _evictionMsg2 = "In Index4";

        return View("Index");
    }


    #region snippet_ed
    public IActionResult EvictDependency()
    {
        _evictionMsg2 = "in EvictDependency";
        using (var entry = _memoryCache.CreateEntry(CacheKeyMS2))
        {
            // expire this entry if the dependant entry expires.
            entry.Value = DateTime.Now.TimeOfDay.Milliseconds.ToString();
            entry.RegisterPostEvictionCallback(AfterEvicted2, this);

            _memoryCache.Set(CacheKeyMS3,
                DateTime.Now.AddMilliseconds(4).TimeOfDay.Milliseconds.ToString(),
                new CancellationChangeToken(_cts2.Token));
        }

        return RedirectToAction("CheckEvictDependency");
    }

    public IActionResult CheckEvictDependency(int? id)
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
    #endregion

    private static void AfterEvicted2(object key, object value,
    EvictionReason reason, object state)
    {
        ((HomeController)state)._evictionMsg2 = $"key: {key}, Value: {value}, Reason: {reason}";
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

