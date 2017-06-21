Private Sub AddCacheItem(ByVal rawKey As String, ByVal value As Object)
    Dim DataCache As System.Web.Caching.Cache = HttpRuntime.Cache
    ' Make sure MasterCacheKeyArray[0] is in the cache - if not, add it
    If DataCache(MasterCacheKeyArray(0)) Is Nothing Then
        DataCache(MasterCacheKeyArray(0)) = DateTime.Now
    End If
    ' Add a CacheDependency
    Dim dependency As New Caching.CacheDependency(Nothing, MasterCacheKeyArray) _
        DataCache.Insert(GetCacheKey(rawKey), value, dependency, _
        DateTime.Now.AddSeconds(CacheDuration), _
        System.Web.Caching.Cache.NoSlidingExpiration)
End Sub