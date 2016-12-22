private void AddCacheItem(string rawKey, object value)
{
    System.Web.Caching.Cache DataCache = HttpRuntime.Cache;
    // Make sure MasterCacheKeyArray[0] is in the cache - if not, add it
    if (DataCache[MasterCacheKeyArray[0]] == null)
        DataCache[MasterCacheKeyArray[0]] = DateTime.Now;
    // Add a CacheDependency
    System.Web.Caching.CacheDependency dependency = 
        new CacheDependency(null, MasterCacheKeyArray);
    DataCache.Insert(GetCacheKey(rawKey), value, dependency, 
        DateTime.Now.AddSeconds(CacheDuration), 
        System.Web.Caching.Cache.NoSlidingExpiration);
}