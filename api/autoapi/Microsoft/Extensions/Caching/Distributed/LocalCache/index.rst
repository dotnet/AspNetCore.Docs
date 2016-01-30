

LocalCache Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Distributed.LocalCache`








Syntax
------

.. code-block:: csharp

   public class LocalCache : IDistributedCache





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Memory/LocalCache.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.Distributed.LocalCache

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.Distributed.LocalCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.Distributed.LocalCache.LocalCache(Microsoft.Extensions.Caching.Memory.IMemoryCache)
    
        
        
        
        :type memoryCache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           public LocalCache(IMemoryCache memoryCache)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Distributed.LocalCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.Connect()
    
        
    
        
        .. code-block:: csharp
    
           public void Connect()
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.ConnectAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task ConnectAsync()
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.Get(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public byte[] Get(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.GetAsync(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task{System.Byte[]}
    
        
        .. code-block:: csharp
    
           public Task<byte[]> GetAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.Refresh(System.String)
    
        
        
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void Refresh(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.RefreshAsync(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RefreshAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.Remove(System.String)
    
        
        
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void Remove(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.RemoveAsync(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RemoveAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.Set(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Byte[]
        
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
           public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.LocalCache.SetAsync(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Byte[]
        
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    

