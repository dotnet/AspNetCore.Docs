

DistributedCacheTagHelperStorage Class
======================================






Implements :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage` by storing the content
in using :any:`Microsoft.Extensions.Caching.Distributed.IDistributedCache` as the store.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage`








Syntax
------

.. code-block:: csharp

    public class DistributedCacheTagHelperStorage : IDistributedCacheTagHelperStorage








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage.DistributedCacheTagHelperStorage(Microsoft.Extensions.Caching.Distributed.IDistributedCache)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage`\.
    
        
    
        
        :param distributedCache: The :any:`Microsoft.Extensions.Caching.Distributed.IDistributedCache` to use.
        
        :type distributedCache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        .. code-block:: csharp
    
            public DistributedCacheTagHelperStorage(IDistributedCache distributedCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage.GetAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Byte<System.Byte>[]}
    
        
        .. code-block:: csharp
    
            public Task<byte[]> GetAsync(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage.SetAsync(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    

