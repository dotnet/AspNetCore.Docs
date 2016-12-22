private object GetCacheItem(string rawKey)
{
    return HttpRuntime.Cache[GetCacheKey(rawKey)];
}
private readonly string[] MasterCacheKeyArray = {"ProductsCache"};
private string GetCacheKey(string cacheKey)
{
    return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
}