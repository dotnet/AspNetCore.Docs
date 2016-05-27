

MemoryDistributedCache Class
============================





Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Distributed`
Assemblies
    * Microsoft.Extensions.Caching.Memory

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache`








Syntax
------

.. code-block:: csharp

    public class MemoryDistributedCache : IDistributedCache








.. dn:class:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.MemoryDistributedCache(Microsoft.Extensions.Caching.Memory.IMemoryCache)
    
        
    
        
        :type memoryCache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            public MemoryDistributedCache(IMemoryCache memoryCache)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.Get(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Get(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.GetAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Byte<System.Byte>[]}
    
        
        .. code-block:: csharp
    
            public Task<byte[]> GetAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.Refresh(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Refresh(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.RefreshAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RefreshAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.Remove(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Remove(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.RemoveAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RemoveAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.Set(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.MemoryDistributedCache.SetAsync(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    

