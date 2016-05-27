

SqlServerCachingServicesExtensions Class
========================================






Extension methods for setting up Microsoft SQL Server distributed cache services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.Caching.SqlServer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions`








Syntax
------

.. code-block:: csharp

    public class SqlServerCachingServicesExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions.AddDistributedSqlServerCache(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions>)
    
        
    
        
        Adds Microsoft SQL Server distributed caching services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions<Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddDistributedSqlServerCache(IServiceCollection services, Action<SqlServerCacheOptions> setupAction)
    

