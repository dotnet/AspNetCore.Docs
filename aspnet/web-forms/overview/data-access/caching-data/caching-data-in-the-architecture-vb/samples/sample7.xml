Const CacheDuration As Double = 60.0
Private Sub AddCacheItem(ByVal rawKey As String, ByVal value As Object)
    DataCache.Insert(GetCacheKey(rawKey), value, Nothing, _
        DateTime.Now.AddSeconds(CacheDuration), _
        System.Web.Caching.Cache.NoSlidingExpiration)
End Sub