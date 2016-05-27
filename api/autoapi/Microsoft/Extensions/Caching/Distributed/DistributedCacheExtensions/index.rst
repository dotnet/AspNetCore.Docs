

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

    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.Set(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.Byte[])
    
        
    
        
        Sets a sequence of bytes in the specified cache with the specified key.
    
        
    
        
        :param cache: The cache in which to store the data.
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :param key: The key to store the data in.
        
        :type key: System.String
    
        
        :param value: The data to store in the cache.
        
        :type value: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static void Set(IDistributedCache cache, string key, byte[] value)
    
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
    
            public static Task SetAsync(IDistributedCache cache, string key, byte[] value)
    

