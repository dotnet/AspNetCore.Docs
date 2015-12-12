

CacheExtensions Class
=====================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Abstractions/MemoryCacheExtensions.cs>`_





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
    
           public static object Get(IMemoryCache cache, object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Get<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type key: System.Object
        :rtype: {TItem}
    
        
        .. code-block:: csharp
    
           public static TItem Get<TItem>(IMemoryCache cache, object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, System.Object)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type key: System.Object
        
        
        :type value: System.Object
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public static object Set(IMemoryCache cache, object key, object value)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, System.Object, Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type key: System.Object
        
        
        :type value: System.Object
        
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public static object Set(IMemoryCache cache, object key, object value, MemoryCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, TItem)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type key: System.Object
        
        
        :type value: {TItem}
        :rtype: {TItem}
    
        
        .. code-block:: csharp
    
           public static TItem Set<TItem>(IMemoryCache cache, object key, TItem value)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.Set<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, TItem, Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type key: System.Object
        
        
        :type value: {TItem}
        
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
        :rtype: {TItem}
    
        
        .. code-block:: csharp
    
           public static TItem Set<TItem>(IMemoryCache cache, object key, TItem value, MemoryCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheExtensions.TryGetValue<TItem>(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Object, out TItem)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type key: System.Object
        
        
        :type value: {TItem}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryGetValue<TItem>(IMemoryCache cache, object key, out TItem value)
    

