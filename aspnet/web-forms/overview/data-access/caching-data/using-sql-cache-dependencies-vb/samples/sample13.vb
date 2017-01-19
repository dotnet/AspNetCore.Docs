Private Sub AddCacheItem(ByVal rawKey As String, ByVal value As Object)
    Dim DataCache As System.Web.Caching.Cache = HttpRuntime.Cache
    ' Add the SqlCacheDependency objects for Products
    Dim productsTableDependency As New _
        Caching.SqlCacheDependency("NorthwindDB", "Products")
    DataCache.Insert(GetCacheKey(rawKey), value, productsTableDependency, _
        Cache.NoAbsoluteExpiration, Caching.Cache.NoSlidingExpiration)
End Sub