

DistributedCacheExtensions Class
================================






Extension methods for setting data in an :any:`Microsoft.Extensions.Caching.Distributed.IDistributedCache`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Distributed`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions`








Syntax
------

.. code-block:: csharp

    public class DistributedCacheExtensions








.. dn:class:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.GetString(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String)
    
        
    
        
        Gets a string from the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to get the stored data for.
        
        :type key: System.String
        :rtype: System.String
        :return: The string value from the stored cache key.
    
        
        .. code-block:: csharp
    
            public static string GetString(this IDistributedCache cache, string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.GetStringAsync(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String)
    
        
    
        
        Asynchronously gets a string from the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to get the stored data for.
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A task that gets the string value from the stored cache key.
    
        
        .. code-block:: csharp
    
            public static Task<string> GetStringAsync(this IDistributedCache cache, string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.Set(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.Byte[])
    
        
    
        
        Sets a sequence of bytes in the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to store the data in.
        
        :type key: System.String
    
        
        :param value: The data to store in the cache.
        
        :type value: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static void Set(this IDistributedCache cache, string key, byte[] value)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetAsync(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.Byte[])
    
        
    
        
        Asynchronously sets a sequence of bytes in the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to store the data in.
        
        :type key: System.String
    
        
        :param value: The data to store in the cache.
        
        :type value: System.Byte<System.Byte>[]
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous set operation.
    
        
        .. code-block:: csharp
    
            public static Task SetAsync(this IDistributedCache cache, string key, byte[] value)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetString(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.String)
    
        
    
        
        Sets a string in the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to store the data in.
        
        :type key: System.String
    
        
        :param value: The data to store in the cache.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public static void SetString(this IDistributedCache cache, string key, string value)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetString(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.String, Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        Sets a string in the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to store the data in.
        
        :type key: System.String
    
        
        :param value: The data to store in the cache.
        
        :type value: System.String
    
        
        :param options: The cache options for the entry.
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static void SetString(this IDistributedCache cache, string key, string value, DistributedCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetStringAsync(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.String)
    
        
    
        
        Asynchronously sets a string in the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to store the data in.
        
        :type key: System.String
    
        
        :param value: The data to store in the cache.
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous set operation.
    
        
        .. code-block:: csharp
    
            public static Task SetStringAsync(this IDistributedCache cache, string key, string value)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetStringAsync(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.String, Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        Asynchronously sets a string in the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to store the data in.
        
        :type key: System.String
    
        
        :param value: The data to store in the cache.
        
        :type value: System.String
    
        
        :param options: The cache options for the entry.
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous set operation.
    
        
        .. code-block:: csharp
    
            public static Task SetStringAsync(this IDistributedCache cache, string key, string value, DistributedCacheEntryOptions options)
    

