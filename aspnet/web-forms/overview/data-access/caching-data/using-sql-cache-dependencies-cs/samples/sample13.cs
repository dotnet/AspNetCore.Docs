private void AddCacheItem(string rawKey, object value)
{
    System.Web.Caching.Cache DataCache = HttpRuntime.Cache;
    // Add the SqlCacheDependency objects for Products
    Caching.SqlCacheDependency productsTableDependency = 
        new Caching.SqlCacheDependency("NorthwindDB", "Products");
    // Add the item to the data cache using productsTableDependency
    DataCache.Insert(GetCacheKey(rawKey), value, productsTableDependency, 
        Caching.Cache.NoAbsoluteExpiration, Caching.Cache.NoSlidingExpiration);
}