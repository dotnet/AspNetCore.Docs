

LoggingServiceCollectionExtensions Class
========================================






Extension methods for setting up logging services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.Logging

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class LoggingServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds logging services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddLogging(this IServiceCollection services)
    

