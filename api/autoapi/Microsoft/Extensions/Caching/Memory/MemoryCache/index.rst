

MemoryCache Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCache`








Syntax
------

.. code-block:: csharp

   public class MemoryCache : IMemoryCache, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.Memory/MemoryCache.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCache

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.Memory.MemoryCache.MemoryCache(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.Extensions.Caching.Memory.MemoryCacheOptions>)
    
        
    
        Creates a new MemoryCache instance.
    
        
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.Extensions.Caching.Memory.MemoryCacheOptions}
    
        
        .. code-block:: csharp
    
           public MemoryCache(IOptions<MemoryCacheOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.Compact(System.Double)
    
        
        
        
        :type percentage: System.Double
    
        
        .. code-block:: csharp
    
           public void Compact(double percentage)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.CreateLinkingScope()
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IEntryLink
    
        
        .. code-block:: csharp
    
           public IEntryLink CreateLinkingScope()
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.Finalize()
    
        
    
        Cleans up the background collection events.
    
        
    
        
        .. code-block:: csharp
    
           protected void Finalize()
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.Remove(System.Object)
    
        
        
        
        :type key: System.Object
    
        
        .. code-block:: csharp
    
           public void Remove(object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.Set(System.Object, System.Object, Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions)
    
        
        
        
        :type key: System.Object
        
        
        :type value: System.Object
        
        
        :type cacheEntryOptions: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Set(object key, object value, MemoryCacheEntryOptions cacheEntryOptions)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.TryGetValue(System.Object, out System.Object)
    
        
        
        
        :type key: System.Object
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(object key, out object value)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCache
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCache.Count
    
        
    
        Gets the count of the current entries for diagnostic purposes.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    

