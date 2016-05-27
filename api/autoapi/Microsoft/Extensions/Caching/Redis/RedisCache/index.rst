

RedisCache Class
================





Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Redis`
Assemblies
    * Microsoft.Extensions.Caching.Redis

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Redis.RedisCache`








Syntax
------

.. code-block:: csharp

    public class RedisCache : IDistributedCache, IDisposable








.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCache
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCache

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.Redis.RedisCache.RedisCache(Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Caching.Redis.RedisCacheOptions>)
    
        
    
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.Extensions.Caching.Redis.RedisCacheOptions<Microsoft.Extensions.Caching.Redis.RedisCacheOptions>}
    
        
        .. code-block:: csharp
    
            public RedisCache(IOptions<RedisCacheOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.Get(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Get(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.GetAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Byte<System.Byte>[]}
    
        
        .. code-block:: csharp
    
            public Task<byte[]> GetAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.Refresh(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Refresh(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.RefreshAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RefreshAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.Remove(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Remove(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.RemoveAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RemoveAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.Set(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.SetAsync(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    

