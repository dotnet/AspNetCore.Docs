

SqlServerCache Class
====================






Distributed cache implementation using Microsoft SQL Server database.


Namespace
    :dn:ns:`Microsoft.Extensions.Caching.SqlServer`
Assemblies
    * Microsoft.Extensions.Caching.SqlServer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.SqlServer.SqlServerCache`








Syntax
------

.. code-block:: csharp

    public class SqlServerCache : IDistributedCache








.. dn:class:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.SqlServerCache(Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions>)
    
        
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions<Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions>}
    
        
        .. code-block:: csharp
    
            public SqlServerCache(IOptions<SqlServerCacheOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.Get(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Get(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.GetAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Byte<System.Byte>[]}
    
        
        .. code-block:: csharp
    
            public Task<byte[]> GetAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.Refresh(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Refresh(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.RefreshAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RefreshAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.Remove(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Remove(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.RemoveAsync(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RemoveAsync(string key)
    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.Set(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.SqlServer.SqlServerCache.SetAsync(System.String, System.Byte[], Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    

