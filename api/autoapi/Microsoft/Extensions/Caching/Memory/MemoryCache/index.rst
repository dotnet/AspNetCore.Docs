

MemoryCache Class
=================






An implementation of :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` using a dictionary to
store its entries.


Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Memory

----

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








.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCache
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCache

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.Memory.MemoryCache.MemoryCache(Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Caching.Memory.MemoryCacheOptions>)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Caching.Memory.MemoryCache` instance.
    
        
    
        
        :param optionsAccessor: The options of the cache.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.Extensions.Caching.Memory.MemoryCacheOptions<Microsoft.Extensions.Caching.Memory.MemoryCacheOptions>}
    
        
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
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.CreateEntry(System.Object)
    
        
    
        
        :type key: System.Object
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public ICacheEntry CreateEntry(object key)
    
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
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCache.TryGetValue(System.Object, out System.Object)
    
        
    
        
        :type key: System.Object
    
        
        :type result: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(object key, out object result)
    

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
    

