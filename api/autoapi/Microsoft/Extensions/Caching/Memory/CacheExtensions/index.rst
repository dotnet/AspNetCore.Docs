

CacheExtensions Class
=====================





Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Memory.CacheExtensions`








Syntax
------

.. code-block:: csharp

    public class CacheExtensions








.. dn:class:: Microsoft.Extensions.Caching.Memory.CacheExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Memory.CacheExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Memory.CacheExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Get(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public static object Get(this IMemoryCache cache, object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, System.Func<Microsoft.Extensions.Caching.Memory.ICacheEntry, System.Threading.Tasks.Task<TItem>>)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type factory: System.Func<System.Func`2>{Microsoft.Extensions.Caching.Memory.ICacheEntry<Microsoft.Extensions.Caching.Memory.ICacheEntry>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TItem}}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TItem}
    
        
        .. code-block:: csharp
    
            public static Task<TItem> GetOrCreateAsync<TItem>(this IMemoryCache cache, object key, Func<ICacheEntry, Task<TItem>> factory)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, System.Func<Microsoft.Extensions.Caching.Memory.ICacheEntry, TItem>)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type factory: System.Func<System.Func`2>{Microsoft.Extensions.Caching.Memory.ICacheEntry<Microsoft.Extensions.Caching.Memory.ICacheEntry>, TItem}
        :rtype: TItem
    
        
        .. code-block:: csharp
    
            public static TItem GetOrCreate<TItem>(this IMemoryCache cache, object key, Func<ICacheEntry, TItem> factory)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Get<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
        :rtype: TItem
    
        
        .. code-block:: csharp
    
            public static TItem Get<TItem>(this IMemoryCache cache, object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, TItem)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type value: TItem
        :rtype: TItem
    
        
        .. code-block:: csharp
    
            public static TItem Set<TItem>(this IMemoryCache cache, object key, TItem value)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, TItem, Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type value: TItem
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
        :rtype: TItem
    
        
        .. code-block:: csharp
    
            public static TItem Set<TItem>(this IMemoryCache cache, object key, TItem value, MemoryCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, TItem, Microsoft.Extensions.Primitives.IChangeToken)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type value: TItem
    
        
        :type expirationToken: Microsoft.Extensions.Primitives.IChangeToken
        :rtype: TItem
    
        
        .. code-block:: csharp
    
            public static TItem Set<TItem>(this IMemoryCache cache, object key, TItem value, IChangeToken expirationToken)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, TItem, System.DateTimeOffset)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type value: TItem
    
        
        :type absoluteExpiration: System.DateTimeOffset
        :rtype: TItem
    
        
        .. code-block:: csharp
    
            public static TItem Set<TItem>(this IMemoryCache cache, object key, TItem value, DateTimeOffset absoluteExpiration)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, TItem, System.TimeSpan)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type value: TItem
    
        
        :type absoluteExpirationRelativeToNow: System.TimeSpan
        :rtype: TItem
    
        
        .. code-block:: csharp
    
            public static TItem Set<TItem>(this IMemoryCache cache, object key, TItem value, TimeSpan absoluteExpirationRelativeToNow)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.TryGetValue<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, out TItem)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :type key: System.Object
    
        
        :type value: TItem
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryGetValue<TItem>(this IMemoryCache cache, object key, out TItem value)
    

