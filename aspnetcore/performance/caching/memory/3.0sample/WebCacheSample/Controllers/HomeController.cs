using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using WebCacheSample.Models;

#region snippet_ctor
public class HomeController : Controller
{
    private IMemoryCache cache;

    public HomeController(IMemoryCache memoryCache)
    {
        this.cache = memoryCache;
    }
    #endregion

    public IActionResult Index()
    {
        return RedirectToAction("CacheGet");
    }

    #region snippet1
    public IActionResult CacheTryGetValueSet()
    {
        DateTime cacheEntry;

        // Look for cache key.
        if (!cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
        {
            // Key not in cache, so get data.
            cacheEntry = DateTime.Now;

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromSeconds(3));

            // Save data in cache.
            cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
        }

        return View("Cache", cacheEntry);
    }
    #endregion

    #region snippet_gct
    public IActionResult CacheGet()
    {
        var cacheEntry = cache.Get<DateTime?>(CacheKeys.Entry);
        return View("Cache", cacheEntry);
    }
    #endregion

    #region snippet2
    public IActionResult CacheGetOrCreate()
    {
        var cacheEntry = cache.GetOrCreate(CacheKeys.Entry, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(3);
            return DateTime.Now;
        });

        return View("Cache", cacheEntry);
    }

    public async Task<IActionResult> CacheGetOrCreateAsynchronous()
    {
        var cacheEntry = await
            cache.GetOrCreateAsync(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return Task.FromResult(DateTime.Now);
            });

        return View("Cache", cacheEntry);
    }
    #endregion

    #region snippet_set
    public IActionResult SetCacheRelativeExpiration()
    {
        DateTime cacheEntry;

        // Look for cache key.
        if (!cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
        {
            // Key not in cache, so get data.
            cacheEntry = DateTime.Now;

            // Save data in cache and set the relative expiration time to one day
            cache.Set(CacheKeys.Entry, cacheEntry, TimeSpan.FromDays(1));
        }

        return View("Cache", cacheEntry);
    }
    #endregion

    public IActionResult CacheRemove()
    {
        cache.Remove(CacheKeys.Entry);
        return RedirectToAction("CacheGet");
    }

    #region snippet_et
    public IActionResult CreateCallbackEntry()
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            // Pin to cache.
            .SetPriority(CacheItemPriority.NeverRemove)
            // Add eviction callback
            .RegisterPostEvictionCallback(callback: EvictionCallback, state: this);

        cache.Set(CacheKeys.CallbackEntry, DateTime.Now, cacheEntryOptions);

        return RedirectToAction("GetCallbackEntry");
    }

    public IActionResult GetCallbackEntry()
    {
        return View("Callback", new CallbackViewModel
        {
            CachedTime = cache.Get<DateTime?>(CacheKeys.CallbackEntry),
            Message = cache.Get<string>(CacheKeys.CallbackMessage)
        });
    }

    public IActionResult RemoveCallbackEntry()
    {
        cache.Remove(CacheKeys.CallbackEntry);
        return RedirectToAction("GetCallbackEntry");
    }

    private static void EvictionCallback(object key, object value,
        EvictionReason reason, object state)
    {
        var message = $"Entry was evicted. Reason: {reason}.";
        ((HomeController)state).cache.Set(CacheKeys.CallbackMessage, message);
    }
    #endregion

    #region snippet_ed
    public IActionResult CreateDependentEntries()
    {
        var cts = new CancellationTokenSource();
        cache.Set(CacheKeys.DependentCTS, cts);

        using (var entry = cache.CreateEntry(CacheKeys.Parent))
        {
            // expire this entry if the dependant entry expires.
            entry.Value = DateTime.Now;
            entry.RegisterPostEvictionCallback(DependentEvictionCallback, this);

            cache.Set(CacheKeys.Child,
                DateTime.Now,
                new CancellationChangeToken(cts.Token));
        }

        return RedirectToAction("GetDependentEntries");
    }

    public IActionResult GetDependentEntries()
    {
        return View("Dependent", new DependentViewModel
        {
            ParentCachedTime = cache.Get<DateTime?>(CacheKeys.Parent),
            ChildCachedTime = cache.Get<DateTime?>(CacheKeys.Child),
            Message = cache.Get<string>(CacheKeys.DependentMessage)
        });
    }

    public IActionResult RemoveChildEntry()
    {
        cache.Get<CancellationTokenSource>(CacheKeys.DependentCTS).Cancel();
        return RedirectToAction("GetDependentEntries");
    }

    private static void DependentEvictionCallback(object key, object value,
        EvictionReason reason, object state)
    {
        var message = $"Parent entry was evicted. Reason: {reason}.";
        ((HomeController)state)._cache.Set(CacheKeys.DependentMessage, message);
    }
    #endregion

    #region snippet_cancel
    public IActionResult CancelTest()
    {
        var cachedVal = DateTime.Now.Second.ToString();
        CancellationTokenSource cts = new CancellationTokenSource();
        cache.Set<CancellationTokenSource>(CacheKeys.CancelTokenSource, cts);

        // Don't use previous message.
        cache.Remove(CacheKeys.CancelMsg);

        cache.Set(CacheKeys.Ticks, cachedVal,
            new MemoryCacheEntryOptions()
            .AddExpirationToken(new CancellationChangeToken(cts.Token))
            .RegisterPostEvictionCallback(
                (key, value, reason, substate) =>
                {
                    var cm = $"'{key}':'{value}' was evicted because: {reason}";
                    cache.Set<string>(CacheKeys.CancelMsg, cm);
                }
            ));

        return RedirectToAction("CheckCancel");
    }

    public IActionResult CheckCancel(int? id = 0)
    {
        if (id > 0)
        {
            CancellationTokenSource cts =
               cache.Get<CancellationTokenSource>(CacheKeys.CancelTokenSource);
            cts.CancelAfter(100);
            // Cancel immediately with cts.Cancel();
        }

        ViewData["CachedTime"] = cache.Get<string>(CacheKeys.Ticks);
        ViewData["Message"] = cache.Get<string>(CacheKeys.CancelMsg); ;

        return View();
    }
    #endregion

    #region snippet99
    public IActionResult CacheGetOrCreateAbs()
    {
        var cacheEntry = cache.GetOrCreate(CacheKeys.Entry, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
            return DateTime.Now;
        });

        return View("Cache", cacheEntry);
    }
    #endregion

    #region snippet9
    public IActionResult CacheGetOrCreateAbsSliding()
    {
        var cacheEntry = cache.GetOrCreate(CacheKeys.Entry, entry =>
        {
            entry.SetSlidingExpiration(TimeSpan.FromSeconds(3));
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
            return DateTime.Now;
        });

        return View("Cache", cacheEntry);
    }
    #endregion

    #region snippet_ae
    public IActionResult CacheAutoExpiringTryGetValueSet()
    {
        DateTime cacheEntry;

        if (!cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
        {
            cacheEntry = DateTime.Now;

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(cts.Token));

            cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
        }

        return View("Cache", cacheEntry);
    }
    #endregion
    public IActionResult Privacy()
    {
        return View();
    }
}
