const double CacheDuration = 60.0;
private void AddCacheItem(string rawKey, object value)
{
    HttpRuntime.Cache.Insert(GetCacheKey(rawKey), value, null, 
        DateTime.Now.AddSeconds(CacheDuration), Caching.Cache.NoSlidingExpiration);
}