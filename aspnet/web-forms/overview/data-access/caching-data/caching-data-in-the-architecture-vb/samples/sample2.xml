Dim instance As Type = TryCast(Cache("key"), Type)
If instance Is Nothing Then
    instance = BllMethodToGetInstance()
    Cache.Insert(key, instance, ...)
End If
Return instance