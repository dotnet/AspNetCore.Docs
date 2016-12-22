private void AddCacheItem(string rawKey, object value)
{
    System.Web.Caching.Cache DataCache = HttpRuntime.Cache;
    // Make sure MasterCacheKeyArray[0] is in the cache and create a depedency
    DataCache[MasterCacheKeyArray[0]] = DateTime.Now;
    Caching.CacheDependency masterCacheKeyDependency = 
        new Caching.CacheDependency(null, MasterCacheKeyArray);
    // Add the SqlCacheDependency objects for Products, Categories, and Suppliers
    Caching.SqlCacheDependency productsTableDependency = 
        new Caching.SqlCacheDependency("NorthwindDB", "Products");
    Caching.SqlCacheDependency categoriesTableDependency = 
        new Caching.SqlCacheDependency("NorthwindDB", "Categories");
    Caching.SqlCacheDependency suppliersTableDependency = 
        new Caching.SqlCacheDependency("NorthwindDB", "Suppliers");
    // Create an AggregateCacheDependency
    Caching.AggregateCacheDependency aggregateDependencies = 
        new Caching.AggregateCacheDependency();
    aggregateDependencies.Add(masterCacheKeyDependency, productsTableDependency, 
        categoriesTableDependency, suppliersTableDependency);
    DataCache.Insert(GetCacheKey(rawKey), value, aggregateDependencies, 
        Caching.Cache.NoAbsoluteExpiration, Caching.Cache.NoSlidingExpiration);
}