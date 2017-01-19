If Cache("key") Is Nothing Then
    Cache.Insert(key, BllMethodToGetInstance(), ...)
End If
Return Cache("key")