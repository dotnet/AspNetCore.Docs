using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using WebCacheSample.Models;

// <snippet_ctor>
public class HomeController : Controller
{
    private IMemoryCache _cache;

    public HomeController(IMemoryCache memoryCache)
    {
        _cache = memoryCache;
    }
    // </snippet_ctor>

    public IActionResult Index()
    {
        return RedirectToAction("CacheGet");
    }

    // <snippet1>
    public IActionResult CacheTryGetValueSet()
    {
        DateTime cacheEntry;

        // Look for cache key.
        if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
        {
            // Key not in cache, so get data.
            cacheEntry = DateTime.Now;

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromSeconds(3));

            // Save data in cache.
            _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
        }

        return View("Cache", cacheEntry);
    }
    // </snippet1>

    // <snippet_gct>
    public IActionResult CacheGet()
    {
        var cacheEntry = _cache.Get<DateTime?>(CacheKeys.Entry);
        return View("Cache", cacheEntry);
    }
    // </snippet_gct>

    // <snippet2>
    public IActionResult CacheGetOrCreate()
    {
        var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(3);
            return DateTime.Now;
        });

        return View("Cache", cacheEntry);
    }

    public async Task<IActionResult> CacheGetOrCreateAsynchronous()
    {
        var cacheEntry = await
            _cache.GetOrCreateAsync(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return Task.FromResult(DateTime.Now);
            });

        return View("Cache", cacheEntry);
    }
    // </snippet2>

    // <snippet_set>
    public IActionResult SetCacheRelativeExpiration()
    {
        DateTime cacheEntry;

        // Look for cache key.
        if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
        {
            // Key not in cache, so get data.
            cacheEntry = DateTime.Now;

            // Save data in cache and set the relative expiration time to one day
            _cache.Set(CacheKeys.Entry, cacheEntry, TimeSpan.FromDays(1));
        }

        return View("Cache", cacheEntry);
    }
    // </snippet_set>

    public IActionResult CacheRemove()
    {
        _cache.Remove(CacheKeys.Entry);
        return RedirectToAction("CacheGet");
    }

    // <snippet_et>
    public IActionResult CreateCallbackEntry()
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            // Pin to cache.
            .SetPriority(CacheItemPriority.NeverRemove)
            // Add eviction callback
            .RegisterPostEvictionCallback(callback: EvictionCallback, state: this);

        _cache.Set(CacheKeys.CallbackEntry, DateTime.Now, cacheEntryOptions);

        return RedirectToAction("GetCallbackEntry");
    }

    public IActionResult GetCallbackEntry()
    {
        return View("Callback", new CallbackViewModel
        {
            CachedTime = _cache.Get<DateTime?>(CacheKeys.CallbackEntry),
            Message = _cache.Get<string>(CacheKeys.CallbackMessage)
        });
    }

    public IActionResult RemoveCallbackEntry()
    {
        _cache.Remove(CacheKeys.CallbackEntry);
        return RedirectToAction("GetCallbackEntry");
    }

    private static void EvictionCallback(object key, object value,
        EvictionReason reason, object state)
    {
        var message = $"Entry was evicted. Reason: {reason}.";
        ((HomeController)state)._cache.Set(CacheKeys.CallbackMessage, message);
    }
    // </snippet_et>

    // <snippet_ed>
    public IActionResult CreateDependentEntries()
    {
        var cts = new CancellationTokenSource();
        _cache.Set(CacheKeys.DependentCTS, cts);

        using (var entry = _cache.CreateEntry(CacheKeys.Parent))
        {
            // expire this entry if the dependant entry expires.
            entry.Value = DateTime.Now;
            entry.RegisterPostEvictionCallback(DependentEvictionCallback, this);

            _cache.Set(CacheKeys.Child,
                DateTime.Now,
                new CancellationChangeToken(cts.Token));
        }

        return RedirectToAction("GetDependentEntries");
    }

    public IActionResult GetDependentEntries()
    {
        return View("Dependent", new DependentViewModel
        {
            ParentCachedTime = _cache.Get<DateTime?>(CacheKeys.Parent),
            ChildCachedTime = _cache.Get<DateTime?>(CacheKeys.Child),
            Message = _cache.Get<string>(CacheKeys.DependentMessage)
        });
    }

    public IActionResult RemoveChildEntry()
    {
        _cache.Get<CancellationTokenSource>(CacheKeys.DependentCTS).Cancel();
        return RedirectToAction("GetDependentEntries");
    }

    private static void DependentEvictionCallback(object key, object value,
        EvictionReason reason, object state)
    {
        var message = $"Parent entry was evicted. Reason: {reason}.";
        ((HomeController)state)._cache.Set(CacheKeys.DependentMessage, message);
    }
    // </snippet_ed>

    // <snippet_cancel>
    public IActionResult CancelTest()
    {
        var cachedVal = DateTime.Now.Second.ToString();
        CancellationTokenSource cts = new CancellationTokenSource();
        _cache.Set<CancellationTokenSource>(CacheKeys.CancelTokenSource, cts);

        // Don't use previous message.
        _cache.Remove(CacheKeys.CancelMsg);

        _cache.Set(CacheKeys.Ticks, cachedVal,
            new MemoryCacheEntryOptions()
            .AddExpirationToken(new CancellationChangeToken(cts.Token))
            .RegisterPostEvictionCallback(
                (key, value, reason, substate) =>
                {
                    var cm = $"'{key}':'{value}' was evicted because: {reason}";
                    _cache.Set<string>(CacheKeys.CancelMsg, cm);
                }
            ));

        return RedirectToAction("CheckCancel");
    }

    public IActionResult CheckCancel(int? id = 0)
    {
        if (id > 0)
        {
            CancellationTokenSource cts =
               _cache.Get<CancellationTokenSource>(CacheKeys.CancelTokenSource);
            cts.CancelAfter(100);
            // Cancel immediately with cts.Cancel();
        }

        ViewData["CachedTime"] = _cache.Get<string>(CacheKeys.Ticks);
        ViewData["Message"] = _cache.Get<string>(CacheKeys.CancelMsg);

        return View();
    }
    // </snippet_cancel>

    // <snippet99>
    public IActionResult CacheGetOrCreateAbs()
    {
        var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
            return DateTime.Now;
        });

        return View("Cache", cacheEntry);
    }
    // </snippet99>

    // <snippet9>
    public IActionResult CacheGetOrCreateAbsSliding()
    {
        var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
        {
            entry.SetSlidingExpiration(TimeSpan.FromSeconds(3));
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
            return DateTime.Now;
        });

        return View("Cache", cacheEntry);
    }
    // </snippet9>

    // <snippet_ae>
    public IActionResult CacheAutoExpiringTryGetValueSet()
    {
        DateTime cacheEntry;

        if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
        {
            cacheEntry = DateTime.Now;

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(cts.Token));

            _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
        }

        return View("Cache", cacheEntry);
    }
    // </snippet_ae>
    public IActionResult Privacy()
    {
        return View();
    }
}
