

RedisCache Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Redis.RedisCache`








Syntax
------

.. code-block:: csharp

   public class RedisCache : IDistributedCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.Redis/RedisCache.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCache

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.Redis.RedisCache.RedisCache(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.Extensions.Caching.Redis.RedisCacheOptions>)
    
        
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.Extensions.Caching.Redis.RedisCacheOptions}
    
        
        .. code-block:: csharp
    
           public RedisCache(IOptions<RedisCacheOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.Connect()
    
        
    
        
        .. code-block:: csharp
    
           public void Connect()
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.ConnectAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task ConnectAsync()
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.Get(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public byte[] Get(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.GetAsync(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task{System.Byte[]}
    
        
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
        
        
        :type value: System.Byte[]
        
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
           public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Redis.RedisCache.SetAsync(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Byte[]
        
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    

