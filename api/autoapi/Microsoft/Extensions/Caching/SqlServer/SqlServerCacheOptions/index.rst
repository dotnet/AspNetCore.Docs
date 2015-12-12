

SqlServerCacheOptions Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions`








Syntax
------

.. code-block:: csharp

   public class SqlServerCacheOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.SqlServer/SqlServerCacheOptions.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.ConnectionString
    
        
    
        The connection string to the database.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ConnectionString { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.ExpiredItemsDeletionInterval
    
        
    
        The periodic interval to scan and delete expired items in the cache. Default is 30 minutes.
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? ExpiredItemsDeletionInterval { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.SchemaName
    
        
    
        The schema name of the table.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SchemaName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.SystemClock
    
        
    
        An abstraction to represent the clock of a machine in order to enable unit testing.
    
        
        :rtype: Microsoft.Extensions.Internal.ISystemClock
    
        
        .. code-block:: csharp
    
           public ISystemClock SystemClock { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.TableName
    
        
    
        Name of the table where the cache items are stored.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TableName { get; set; }
    

