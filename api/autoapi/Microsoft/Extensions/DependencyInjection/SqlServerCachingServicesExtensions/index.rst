

SqlServerCachingServicesExtensions Class
========================================



.. contents:: 
   :local:



Summary
-------

Extension methods for setting up Microsoft SQL Server distributed cache related services in an 
:any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions`








Syntax
------

.. code-block:: csharp

   public class SqlServerCachingServicesExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.SqlServer/SqlServerCacheExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions.AddSqlServerCache(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions>)
    
        
    
        Adds Microsoft SQL Server distributed caching services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param options: An action callback to configure a  instance.
        
        :type options: System.Action{Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSqlServerCache(IServiceCollection services, Action<SqlServerCacheOptions> options)
    

