private void AddCacheItem(string rawKey, object value)
{
    System.Web.Caching.Cache DataCache = HttpRuntime.Cache;
    // Make sure MasterCacheKeyArray[0] is in the cache
    DataCache[MasterCacheKeyArray[0]] = DateTime.Now;
    // Add a CacheDependency
    Caching.CacheDependency dependency =
        new Caching.CacheDependency(null, MasterCacheKeyArray);
    DataCache.Insert(GetCacheKey(rawKey), value, dependency, 
        DateTime.Now.AddSeconds(CacheDuration), 
        System.Web.Caching.Cache.NoSlidingExpiration);
}