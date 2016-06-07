

IDistributedCacheTagHelperStorage Interface
===========================================






An implementation of this interface provides a service to 
cache distributed html fragments from the <distributed-cache>
tag helper.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDistributedCacheTagHelperStorage








.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage.GetAsync(System.String)
    
        
    
        
        Gets the content from the cache and deserializes it.
    
        
    
        
        :param key: The unique key to use in the cache.
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Byte<System.Byte>[]}
        :return: The stored value if it exists, <returns>null</returns> otherwise.
    
        
        .. code-block:: csharp
    
            Task<byte[]> GetAsync(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage.SetAsync(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        Sets the content in the cache and serialized it.
    
        
    
        
        :param key: The unique key to use in the cache.
        
        :type key: System.String
    
        
        :param value: The value to cache.
        
        :type value: System.Byte<System.Byte>[]
    
        
        :param options: The cache entry options.
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    

