Private Sub AddCacheItem(ByVal rawKey As String, ByVal value As Object)
    Dim DataCache As System.Web.Caching.Cache = HttpRuntime.Cache
    ' Make sure MasterCacheKeyArray(0) is in the cache - if not, add it.
    If DataCache(MasterCacheKeyArray(0)) Is Nothing Then
        DataCache(MasterCacheKeyArray(0)) = DateTime.Now
    End If
    'Create the CacheDependency
    Dim masterCacheKeyDependency As _
        New Caching.CacheDependency(Nothing, MasterCacheKeyArray)
    ' Add the SqlCacheDependency objects for Products, Categories, and Suppliers
    Dim productsTableDependency As _
        New Caching.SqlCacheDependency("NorthwindDB", "Products")
    Dim categoriesTableDependency As _
        New Caching.SqlCacheDependency("NorthwindDB", "Categories")
    Dim suppliersTableDependency As _
        New Caching.SqlCacheDependency("NorthwindDB", "Suppliers")
    ' Create an AggregateCacheDependency
    Dim aggregateDependencies As New Caching.AggregateCacheDependency()
    aggregateDependencies.Add(masterCacheKeyDependency, productsTableDependency, _
        categoriesTableDependency, suppliersTableDependency)
    DataCache.Insert(GetCacheKey(rawKey), value, aggregateDependencies, _
        Caching.Cache.NoAbsoluteExpiration, Caching.Cache.NoSlidingExpiration)
End Sub