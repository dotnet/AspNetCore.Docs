

RedisCacheOptions Class
=======================






Configuration options for :any:`Microsoft.Extensions.Caching.Redis.RedisCache`\.


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
* :dn:cls:`Microsoft.Extensions.Caching.Redis.RedisCacheOptions`








Syntax
------

.. code-block:: csharp

    public class RedisCacheOptions : IOptions<RedisCacheOptions>








.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCacheOptions
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCacheOptions

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.Redis.RedisCacheOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Redis.RedisCacheOptions.Configuration
    
        
    
        
        The configuration used to connect to Redis.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Configuration { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Redis.RedisCacheOptions.InstanceName
    
        
    
        
        The Redis instance name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string InstanceName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Redis.RedisCacheOptions.Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Caching.Redis.RedisCacheOptions>.Value
    
        
        :rtype: Microsoft.Extensions.Caching.Redis.RedisCacheOptions
    
        
        .. code-block:: csharp
    
            RedisCacheOptions IOptions<RedisCacheOptions>.Value { get; }
    

