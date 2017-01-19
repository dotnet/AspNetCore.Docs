Private Function GetCacheItem(ByVal rawKey As String) As Object
    Return HttpRuntime.Cache(GetCacheKey(rawKey))
End Function
Private ReadOnly MasterCacheKeyArray() As String = {"ProductsCache"}
Private Function GetCacheKey(ByVal cacheKey As String) As String
    Return String.Concat(MasterCacheKeyArray(0), "-", cacheKey)
End Function